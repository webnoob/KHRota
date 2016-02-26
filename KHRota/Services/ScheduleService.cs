﻿using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
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

        public ScheduleService()
        {
            _brotherService = new BrotherService();
            _jobService = new JobService();
        }

        public MeetingSchedule GenerateMeetingSchedule(IEnumerable<Meeting> meetings, SchedulePeriod period)
        {
            var result = new MeetingSchedule();

            foreach (var meeting in meetings)
            {
                var numberOfMeetingsInPeriod = DateTimeHelper.CountDays(meeting.DayOfWeek, DateTime.Now,
                    DateTime.Now.AddMonths(period.Months));

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
    }
}