using System;
using System.Collections.Generic;

namespace KHRota.Classes
{
    public class Meeting : BaseEntity
    {
        private List<Job> _requiredJobs;
        
        public string Name { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime OneOffDateTime { get; set; }

        public MeetingType Type { get; set; }

        public List<Job> RequiredJobs
        {
            get { return _requiredJobs ?? (_requiredJobs = new List<Job>()); }
            set { _requiredJobs = value; }
        }
    }
}