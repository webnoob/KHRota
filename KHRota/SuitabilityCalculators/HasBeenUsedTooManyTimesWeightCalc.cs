using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Services;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class HasBeenUsedTooManyTimesWeightCalc : BaseSuitabilityWeightCalculator
    {
        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var sheduleService = new ScheduleService();
            var timesBrotherUsed = sheduleService.GetBrotherTimesUsedInScheduledPeriod(brother, meetingSchedules);
            var brotherHasUsagesLeft = brother.JobsPerPeriod > timesBrotherUsed;
            var brotherCanStandIn = brother.StandInsPerPeriod + brother.JobsPerPeriod > timesBrotherUsed;

            if (brotherHasUsagesLeft)
                return WeightFactor;

            if (brotherCanStandIn)
                return -WeightFactor; //Minus here as it's not ideal that they have to stand in.

            return -WeightFactor * 2;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}