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
            var meetingBrotherLastHadAnAssignment =
                meetingSchedules.LastOrDefault(meeting => meeting.JobAssignments.Any(j => j.BrotherGuid == brother.Guid));

            if (meetingBrotherLastHadAnAssignment == null) //Not done a job in this schedule
                return WeightFactor;

            var indexOfBrothersLastAssignment = meetingSchedules.IndexOf(meetingBrotherLastHadAnAssignment); //Hasn't had enough meetings rest.
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