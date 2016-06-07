using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Services;

namespace KHRota.Classes
{
    public class ScheduledMeeting
    {
        [NonSerialized]
        private List<JobAssignment> _jobAssignments;

        [NonSerialized]
        private readonly MeetingService _meetingService;

        public ScheduledMeeting()
        {
            _meetingService =new MeetingService();
        }

        public DateTime DateTime { get; set; }

        public string MeetingGuid { get; set; }

        public Meeting Meeting { get { return _meetingService.GetByGuid(MeetingGuid); } } 

        public List<JobAssignment> JobAssignments
        {
            get { return _jobAssignments ?? (_jobAssignments = new List<JobAssignment>()); }
            set { _jobAssignments = value; }
        }

        public List<string> JobAssignmentGuids
        {
            get { return JobAssignments.Select(j => j.Guid).ToList(); }
        } 
    }
}