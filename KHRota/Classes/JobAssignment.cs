using KHRota.Services;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public Brother Brother { get { return _brotherService.GetByGuid(BrotherGuid); } }

        public string JobGuid { get; set; }
        
        [JsonIgnore]
        public Job Job { get { return _jobService.GetByGuid(JobGuid); } }

        public BrotherSuitabilityFactor SuitabilityFactor { get; set; }

        public int Weight { get; set; }
    }
}