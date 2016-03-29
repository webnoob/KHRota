using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Services;

namespace KHRota.Classes
{
    public class Brother : BaseEntity
    {
        private readonly JobService _jobService;

        [NonSerialized]
        private List<Job> _assignedJobs;

        private List<DateTime> _unavailableDates;
        private List<JobExclusion> _jobExclusions;
        private List<string> _assignedJobGuids;

        public Brother()
        {
            _jobService = new JobService();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public int JobsPerPeriod { get; set; }

        public int StandInsPerPeriod { get; set; }

        public int MinimumMeetingsBetweenJobs { get; set; }

        public List<JobExclusion> JobExclusions
        {
            get { return _jobExclusions ?? (_jobExclusions = new List<JobExclusion>()); }
            set { _jobExclusions = value; }
        }

        internal List<Job> AssignedJobs
        {
            get
            {
                _assignedJobs = _jobService.Get().Where(j => AssignedJobGuids.Contains(j.Guid)).ToList();
                if (_assignedJobs.Any())
                    return _assignedJobs;

                return _assignedJobs = new List<Job>();
            }
            set
            {
                _assignedJobs = value;
                _assignedJobGuids = value.Select(j => j.Guid).ToList();
            }
        }

        public List<string> AssignedJobGuids
        {
            get { return _assignedJobGuids ?? (_assignedJobGuids = new List<string>()); }
            set { _assignedJobGuids = value; }
        }

        public List<DateTime> UnavailableDates
        {
            get { return _unavailableDates ?? (_unavailableDates = new List<DateTime>()); }
            set { _unavailableDates = value; }
        }
    }
}