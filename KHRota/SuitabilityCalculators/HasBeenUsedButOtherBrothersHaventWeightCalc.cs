using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Services;
using KHRota.SuitabilityCalculators.Base;

namespace KHRota.SuitabilityCalculators
{
    public class HasBeenUsedButOtherBrothersHaventWeightCalc : BaseSuitabilityWeightCalculator
    {
        private readonly BrotherService _brotherService;

        public HasBeenUsedButOtherBrothersHaventWeightCalc()
        {
            _brotherService = new BrotherService();
        }

        protected override int CalculateWeight(Brother brother, Job jobToAssign, ScheduledMeeting scheduledMeeting, List<ScheduledMeeting> meetingSchedules)
        {
            var brothersAllowedToDoJob = _brotherService.Get()
                .Where(b => _brotherService.AllowedToDoJob(b, jobToAssign)).ToList();
            
            var brothersUsedInScheduleSoFar = new List<Brother>();
            foreach (var meeting in meetingSchedules)
            {
                brothersUsedInScheduleSoFar.AddRange(meeting.JobAssignments.Select(j => j.Brother));
            }

            var brothersNotDoingAnything = brothersAllowedToDoJob.Where(b => !brothersUsedInScheduleSoFar.Select(br => br.Guid).Contains(b.Guid));
            var brotherHasBeenUsedAlready = meetingSchedules.Count(meeting => meeting.JobAssignments.Any(j => j.BrotherGuid == brother.Guid));
            if ((brothersNotDoingAnything.Any() && brotherHasBeenUsedAlready > 0) || brotherHasBeenUsedAlready > 1)
                return -(WeightFactor * brotherHasBeenUsedAlready);

            return WeightFactor;
        }

        public override int WeightFactor
        {
            get { return 10; }
        }
    }
}