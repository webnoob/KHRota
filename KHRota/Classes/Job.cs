using System;
using KHRota.Services;
using Newtonsoft.Json;

namespace KHRota.Classes
{
    public class Job : BaseEntity
    {
        private readonly JobGroupService _jobGroupService;

        public Job()
        {
            _jobGroupService = new JobGroupService();
        }

        public string Name { get; set; }

        public string JobGroupGuid { get; set; }

        public Boolean Disabled { get; set; }

        [JsonIgnore]
        public JobGroup JobGroup
        {
            get { return _jobGroupService.GetByGuid(JobGroupGuid); }
            set { JobGroupGuid = value.Guid; }
        }
    }
}
