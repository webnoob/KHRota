using KHRota.Services;

namespace KHRota.Classes
{
    public class JobAssignment : BaseEntity
    {
        private readonly BrotherService _brotherService;
        private readonly JobService _jobService;

        public JobAssignment()
        {
            _brotherService = new BrotherService();
            _jobService = new JobService();
        }

        public string BrotherGuid { get; set; }
        public Brother Brother { get { return _brotherService.GetByGuid(BrotherGuid); } }

        public string JobGuid { get; set; }
        public Job Job { get { return _jobService.GetByGuid(JobGuid); } }

        public BrotherSuitabilityFactor SuitabilityFactor { get; set; }

        public int Weight { get; set; }
    }
}