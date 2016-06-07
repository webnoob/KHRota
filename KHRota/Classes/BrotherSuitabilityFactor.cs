using System.Collections.Generic;
using System.Linq;
using KHRota.Services;
using Newtonsoft.Json;

namespace KHRota.Classes
{
    public class BrotherSuitabilityFactor
    {
        private readonly BrotherService _brotherService;
        private readonly JobService _jobService;
        private List<SuitabilityFactor> _factors;

        public BrotherSuitabilityFactor()
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

        public List<SuitabilityFactor> Factors
        {
            get { return _factors ?? (_factors = new List<SuitabilityFactor>()); }
            set { _factors = value; }
        }

        public int Weight
        {
            get { return _factors.Sum(f => f.Weight); }
        }
    }
}