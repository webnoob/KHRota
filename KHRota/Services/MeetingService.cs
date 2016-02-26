using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
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
            var meetings = new List<Meeting>();

            var tuesdayMeeting = new Meeting
            {
                Guid = "{1A00D27D-7C73-45C3-A2CA-12213D815348}",
                DayOfWeek = DayOfWeek.Tuesday,
                Time = TimeSpan.Parse("19:00:00")
            };
            tuesdayMeeting.RequiredJobs.AddRange(_jobService.Get());
            meetings.Add(tuesdayMeeting);

            var sundayMeeting = new Meeting
            {
                Guid = "{67ED1CF1-BD99-46A8-986E-62EF88E9B0F8}",
                DayOfWeek = DayOfWeek.Sunday,
                Time = TimeSpan.Parse("10:00:00")
            };
            sundayMeeting.RequiredJobs.AddRange(_jobService.Get());
            meetings.Add(sundayMeeting);

            return meetings;
        }

        public Meeting GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }
    }
}
