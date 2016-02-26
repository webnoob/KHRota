using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class NotInUseWeightCalc : BaseSuitabilityWeightCalculator
    {
        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var brotherInUse = scheduledMeeting.JobAssignments.Any(j => j.Brother.Guid == brother.Guid);
            return brotherInUse ? 0 : WeightFactor;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}