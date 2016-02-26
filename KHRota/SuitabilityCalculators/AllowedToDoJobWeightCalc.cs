using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Services;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class AllowedToDoJobWeightCalc : BaseSuitabilityWeightCalculator
    {
        private readonly BrotherService _brotherService;

        public AllowedToDoJobWeightCalc()
        {
            _brotherService = new BrotherService();
        }

        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var allowed = _brotherService.AllowedToDoJob(brother, jobToAssign);
            return allowed ? WeightFactor : 0;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}