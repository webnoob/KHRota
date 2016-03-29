using System;
using KHRota.Services;
using Newtonsoft.Json;

namespace KHRota.Classes
{
    public class JobExclusion
    {
        private readonly JobService _jobService;

        public JobExclusion()
        {
            _jobService = new JobService();
        }

        public DayOfWeek DayOfWeek { get; set; }

        [JsonIgnore]
        public Job Job
        {
            get { return _jobService.GetByGuid(JobGuid); }
            set { JobGuid = value.Guid; }
        }

        public string JobGuid { get; set; }
    }
}
