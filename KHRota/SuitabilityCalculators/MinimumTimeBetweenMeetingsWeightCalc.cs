using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using KHRota.Classes;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class MinimumTimeBetweenMeetingsWeightCalc : BaseSuitabilityWeightCalculator
    {
        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var indexOfThisMeeting = meetingSchedules.IndexOf(scheduledMeeting);
            var averageSpacingBetweenMeetings = meetingSchedules.Count()/
                                                (brother.JobsPerPeriod + brother.StandInsPerPeriod);
            var meetingBrotherLastHadAnAssignment =
                meetingSchedules.LastOrDefault(meeting => meeting.JobAssignments.Any(j => j.BrotherGuid == brother.Guid));

            if (meetingBrotherLastHadAnAssignment == null) //Not done a job in this schedule
                return WeightFactor;

            var indexOfBrothersLastAssignment = meetingSchedules.IndexOf(meetingBrotherLastHadAnAssignment); //Hasn't had enough meetings rest.

            //Try and apply some weighting so the brother is used evenly through the period instead of all assignments at the start.
            //So if he's been used more times than the average distribution then -WeightFactor.
            if (indexOfBrothersLastAssignment + averageSpacingBetweenMeetings > indexOfThisMeeting)
                return -WeightFactor * 2;
            
            if (indexOfThisMeeting - brother.MinimumMeetingsBetweenJobs > indexOfBrothersLastAssignment)
                return WeightFactor;

            return -WeightFactor;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}