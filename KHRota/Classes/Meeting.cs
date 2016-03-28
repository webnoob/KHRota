using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Services;

namespace KHRota.Classes
{
    [Serializable]
    public class Meeting : BaseEntity
    {
        private readonly JobService _jobService;
        
        private List<Job> _requiredJobs;
        private List<string> _requiredJobGuids;

        public Meeting()
        {
            _jobService = new JobService();
        }

        public string Name { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime OneOffDateTime { get; set; }

        public MeetingType Type { get; set; }

        internal List<Job> RequiredJobs
        {
            get
            {
                _requiredJobs = _jobService.Get().ToList();//.Where(j => RequiredJobGuids.Contains(j.Guid)).ToList();
                if (_requiredJobs.Any())
                    return _requiredJobs;

                return _requiredJobs = new List<Job>();
            }
            set
            {
                _requiredJobs = value;
                //_requiredJobGuids = value.Select(j => j.Guid).ToList();
            }
        }

        public List<string> RequiredJobGuids
        {
            get { return _requiredJobGuids ?? (_requiredJobGuids = new List<string>()); }
            set { _requiredJobGuids = value; }
        }
    }
}