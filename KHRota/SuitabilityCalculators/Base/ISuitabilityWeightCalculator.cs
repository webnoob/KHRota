using System.Collections.Generic;
using KHRota.Classes;

namespace KHRota.SuitabilityCalculators.Base
{
    public interface ISuitabilityWeightCalculator
    {
        int WeightFactor { get; }
        SuitabilityWeightCalculatorResult GetSuitability(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules);
    }
}