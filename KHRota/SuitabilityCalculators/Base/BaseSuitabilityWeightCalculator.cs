using System.Collections.Generic;
using KHRota.Classes;

namespace KHRota.SuitabilityCalculators.Base
{
    public abstract class BaseSuitabilityWeightCalculator : ISuitabilityWeightCalculator
    {
        protected abstract int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules);

        public abstract int WeightFactor { get; }

        public SuitabilityWeightCalculatorResult GetSuitability(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var calculatedWeight = CalculateWeight(brother, jobToAssign, scheduledMeeting, meetingSchedules);
            return new SuitabilityWeightCalculatorResult
            {
                SuitabilityFactor = new SuitabilityFactor
                {
                    Weight = calculatedWeight,
                    CalculationSource = this.ToString()
                },
                Status = calculatedWeight == 0
                    ? SuitabilityWeightCalculatorResultStatus.DoNotUse
                    : SuitabilityWeightCalculatorResultStatus.Suitable
            };
        }
    }
}