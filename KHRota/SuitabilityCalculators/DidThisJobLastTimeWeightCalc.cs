using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Services;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class DidThisJobLastTimeWeightCalc : BaseSuitabilityWeightCalculator
    {
        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var scheduleService = new ScheduleService();
            var lastJobForThisBrother = scheduleService.GetBrothersLastJob(brother, meetingSchedules);
            
            if (lastJobForThisBrother == null || lastJobForThisBrother != jobToAssign)
                return WeightFactor;

            return -WeightFactor;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}