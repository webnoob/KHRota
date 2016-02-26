using System;
using System.Collections.Generic;

namespace KHRota.Classes
{
    public class Brother : BaseEntity
    {
        private List<Job> _assignedJobs;
        private List<DateTime> _unavailableDates;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JobsPerPeriod { get; set; }

        public int StandInsPerPeriod { get; set; }

        public int MinimumMeetingsBetweenJobs { get; set; }

        public List<Job> AssignedJobs
        {
            get { return _assignedJobs ?? (_assignedJobs = new List<Job>()); }
            set { _assignedJobs = value; }
        }

        public List<DateTime> UnavailableDates
        {
            get { return _unavailableDates ?? (_unavailableDates = new List<DateTime>()); }
            set { _unavailableDates = value; }
        }
    }
}