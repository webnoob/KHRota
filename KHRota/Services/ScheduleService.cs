using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KHPlayer.Extensions;
using KHRota.Classes;
using KHRota.Data;
using KHRota.Extensions;
using KHRota.Helpers;
using KHRota.SuitabilityCalculators;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.Services
{
    public class ScheduleService
    {
        private readonly BrotherService _brotherService;
        private readonly JobService _jobService;
        private string _historyFilePath;

        public ScheduleService()
        {
            _brotherService = new BrotherService();
            _jobService = new JobService();
            _historyFilePath = Application.StartupPath + "\\ScheduleHistory\\";
        }

        public MeetingSchedule GenerateMeetingSchedule(IEnumerable<Meeting> meetings, SchedulePeriod period)
        {
            var result = Create(period.StartDate);

            DateTime endDate = period.ForceEndDate;
            if (endDate == DateTime.MinValue)
            {
                endDate = new DateTime(period.StartDate.AddMonths(period.Months).Year,
                    period.StartDate.AddMonths(period.Months).Month, 1, 0, 0, 0, period.StartDate.Kind);
                var endOfStartDateMonth = new DateTime(period.StartDate.Year, period.StartDate.Month,
                    DateTime.DaysInMonth(period.StartDate.Year, period.StartDate.Month), 0, 0, 0, period.StartDate.Kind);

                //There are issues when we do a date that's at the end of a month and we're trying to generate it for the next month
                //Add a threshold in where it generates for next month if there are less than X dates left.
                //If we generate the schedule on the 27/04 then it would reset it back to 01/05. This will ensure it goes forward until 01/06
                //Likewise if we generate for 02/08 it will also mean it doesn't skip to 01/10 but instead goes to then end of september.
                var numberOfMeetingsBeforeEndOfStartDateMonth = 0;
                foreach (var meeting in meetings)
                    numberOfMeetingsBeforeEndOfStartDateMonth += DateTimeHelper.CountDays(meeting.DayOfWeek,
                        period.StartDate, endOfStartDateMonth);

                if (numberOfMeetingsBeforeEndOfStartDateMonth < 3)
                    endDate = endDate.AddMonths(1);
            }

            foreach (var meeting in meetings)
            {
                var numberOfMeetingsInPeriod = DateTimeHelper.CountDays(meeting.DayOfWeek, period.StartDate, endDate);

                for (var i = 0; i < numberOfMeetingsInPeriod; i++)
                {
                    var meetingSchedule = new ScheduledMeeting
                    {
                        MeetingGuid = meeting.Guid,
                        DateTime =
                            DateTimeHelper.GetNextWeekday(period.StartDate.AddDays(i*7), meeting.DayOfWeek)
                    };

                    result.ScheduledMeetings.Add(meetingSchedule);
                }
            }

            result.ScheduledMeetings = result.ScheduledMeetings.OrderBy(s => s.DateTime).ToList();
            AssignJobs(result.ScheduledMeetings);
            return result;
        }

        public MeetingSchedule Create(DateTime startDate)
        {
            return new MeetingSchedule
            {
                Guid = Guid.NewGuid().ToString(),
                StartDate = startDate
            };
        }

        private void AssignJobs(List<ScheduledMeeting> meetingSchedules)
        {
            //Get a list of jobs ordered by the least amount of people capable of doing that job
            var listOfJobsOrderedByLeastPeopleCapable = new Dictionary<string, int>();
            foreach (var jobGuid in _brotherService.Get().SelectMany(b => b.AssignedJobs).Select(j => j.Guid))
            {
                if (listOfJobsOrderedByLeastPeopleCapable.ContainsKey(jobGuid))
                    listOfJobsOrderedByLeastPeopleCapable[jobGuid] = listOfJobsOrderedByLeastPeopleCapable[jobGuid] + 1;
                else
                    listOfJobsOrderedByLeastPeopleCapable.Add(jobGuid, 1);
            }
            var jobsToEnumerate =
                listOfJobsOrderedByLeastPeopleCapable.OrderBy(kvp => kvp.Value)
                    .Select(kvp => _jobService.GetByGuid(kvp.Key));

            //Go through all the jobs for the entire schedule with the jobs that the least amount of people can do first.
            //This should mean we fill the hardest to populate roles first, then fill the gaps with people who can do 
            //the other jobs.
            foreach (var jobToAssign in jobsToEnumerate)
            {
                foreach (var meetingSchedule in meetingSchedules)
                {
                    if (!meetingSchedule.Meeting.RequiredJobs.Select(j=> j.Guid).ToList().Contains(jobToAssign.Guid))
                        continue;

                    var suitableBrothers = GetSuitableBrothersForJob(jobToAssign, meetingSchedule, meetingSchedules);
                    if (!suitableBrothers.Any())
                        continue;

                    var brotherSuitabilityFactor =
                        suitableBrothers.OrderByDescending(f => f.Weight).FirstOrDefault();
                    if (brotherSuitabilityFactor == null)
                        continue;
                    //The idea here is that we don't always start with the same brother. Try and randomise it.
                    var brothersWithSameRankRandomised = suitableBrothers.Where(b => b.Weight == brotherSuitabilityFactor.Weight).ToList().Shuffle();
                    brotherSuitabilityFactor = brothersWithSameRankRandomised.FirstOrDefault();

                    var brotherForJob = brotherSuitabilityFactor.Brother;
                    if (brotherForJob == null)
                        continue;
                    
                    var jobAssignment = new JobAssignment
                    {
                        BrotherGuid = brotherForJob.Guid,
                        JobGuid = jobToAssign.Guid,
                        SuitabilityFactor = brotherSuitabilityFactor,
                        Weight = brotherSuitabilityFactor.Weight
                    };

                    meetingSchedule.JobAssignments.Add(jobAssignment);
                }
            }
        }

        public List<BrotherSuitabilityFactor> GetSuitableBrothersForJob(Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var suitableBrothers = new List<BrotherSuitabilityFactor>();
            var type = typeof(BaseSuitabilityWeightCalculator);
            var calculatorTypes = 
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);
            var calculatorInstances = calculatorTypes.Select(Activator.CreateInstance).Cast<BaseSuitabilityWeightCalculator>().ToList();

            foreach (var brother in _brotherService.Get())
            {
                var factors = new List<SuitabilityFactor>();
                foreach (var calculator in calculatorInstances)
                {
                    var calculatedResult = calculator.GetSuitability(brother, jobToAssign, scheduledMeeting, meetingSchedules);
                    if (calculatedResult.Status == SuitabilityWeightCalculatorResultStatus.DoNotUse)
                        goto Skip; //Don't hate me :) It's good to jump out of a loop in a clean way :)

                    factors.Add(calculatedResult.SuitabilityFactor);
                }
                
                var suitableBrotherFactor = new BrotherSuitabilityFactor
                {
                    BrotherGuid = brother.Guid,
                    JobGuid = jobToAssign.Guid,
                    Factors = factors
                };

                suitableBrothers.Add(suitableBrotherFactor);

            Skip:;
            }

            return suitableBrothers;
        }

        public int GetBrotherTimesUsedInScheduledPeriod(Brother brother, List<ScheduledMeeting> meetingSchedules)
        {
            var jobs = meetingSchedules.SelectMany(m => m.JobAssignments.Where(ja => ja.BrotherGuid == brother.Guid));
            return jobs.Count();
        }

        public Job GetBrothersLastJob(Brother brother, List<ScheduledMeeting> meetingSchedules)
        {
            var jobs = meetingSchedules.SelectMany(m => m.JobAssignments.Where(ja => ja.BrotherGuid == brother.Guid)).ToList();
            if (!jobs.Any())
                return null;

            var lastOrDefault = jobs.LastOrDefault();
            if (lastOrDefault == null)
                return null;

            return lastOrDefault.Job;
        }

        public string GetCsv(MeetingSchedule meetingSchedule)
        {
            if (meetingSchedule == null)
                return "";

            var headings = meetingSchedule.ScheduledMeetings.FirstOrDefault()
                .JobAssignments.Aggregate("Date,", (current, job) => current + (job.Job.Name + ","));
            headings += "\r\n";

            var csv = headings;
            foreach (var scheduledMeeting in meetingSchedule.ScheduledMeetings)
            {
                var dateToAdd = scheduledMeeting.DateTime.ToString("dddd dd MMMM");
                csv += dateToAdd + ",";
                foreach (var job in scheduledMeeting.JobAssignments)
                {
                    var jobToAdd = job.Brother.FirstName + " " + job.Brother.LastName + "(" +
                                   job.SuitabilityFactor.Weight + ")";
                    csv += jobToAdd + ",";
                }

                csv = csv.Substring(0, csv.Length - 1) + "\r\n";
            }

            return csv;
        }

        public IEnumerable<string> GetMeetingSchedulesStartDates()
        {
            return Directory.GetFiles(_historyFilePath);
        }

        public void SaveGeneratedMeetingSchedule(MeetingSchedule meetingSchedule)
        {
            //Wait until this folder is created (windows might be a little slow in creation)
            while (!Directory.Exists(_historyFilePath))
                Directory.CreateDirectory(_historyFilePath);

            var fileName = GetMeetingSchduleFileName(meetingSchedule);
            if (fileName == null)
                return;

            meetingSchedule.ToSerializedJson(fileName);
        }

        private string GetMeetingSchduleFileName(MeetingSchedule meetingSchedule)
        {
            if (meetingSchedule == null)
                return null;

            return string.Format("{0}KHRota_{1}.db", _historyFilePath, meetingSchedule.StartDate.ToString("dd-MM-yyyy"));
        }

        public MeetingSchedule LoadFromFile(string fileName)
        {
            return Path.Combine(_historyFilePath, fileName).ToDeserialisedJson<MeetingSchedule>(true);
        }

        public void Delete(MeetingSchedule meetingSchedule)
        {
            File.Delete(GetMeetingSchduleFileName(meetingSchedule));
        }
    }
}
