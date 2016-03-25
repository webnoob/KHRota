using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Data;
using KHRota.Helpers;
using KHRota.Properties;

namespace KHRota.Services
{
    public class MeetingService
    {
        private readonly JobService _jobService;

        public MeetingService()
        {
            _jobService = new JobService();
        }

        public IEnumerable<Meeting> Get()
        {
            return DbStorage.Meetings;
        }

        public Meeting GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }

        public void Update(Meeting meeting)
        {
            Delete(meeting);
            Insert(meeting);
        }

        private Meeting Insert(Meeting meeting)
        {
            if (string.IsNullOrEmpty(meeting.Guid))
                meeting.Guid = Guid.NewGuid().ToString();

            if (Get().FirstOrDefault(p => p.Guid.Equals(meeting.Guid, StringComparison.OrdinalIgnoreCase)) == null)
            {
                DbStorage.Meetings.Add(meeting);
            }

            return meeting;
        }

        public void Delete(Meeting meeting)
        {
            DbStorage.Meetings.Remove(meeting);
        }
    }
}
