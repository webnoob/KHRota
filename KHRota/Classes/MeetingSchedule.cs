using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRota.Classes
{
    [Serializable]
    public class MeetingSchedule : BaseEntity
    {
        private List<ScheduledMeeting> _scheduledMeetings;

        public DateTime StartDate { get; set; }

        public List<ScheduledMeeting> ScheduledMeetings
        {
            get { return _scheduledMeetings ?? (_scheduledMeetings = new List<ScheduledMeeting>()); }
            set { _scheduledMeetings = value; }
        }
    }
}
