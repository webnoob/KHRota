using System;
using System.Collections.Generic;
using KHRota.Services;

namespace KHRota.Classes
{
    public class ScheduledMeeting
    {
        private List<JobAssignment> _jobAssignments;
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
    }
}