using System;
using KHRota.Classes;
using KHRota.Properties;

namespace KHRota.Services
{
    public class TestService
    {
        private MeetingService _meetingService;
        private ScheduleService _scheduleService;

        public TestService()
        {
            _meetingService = new MeetingService();
            _scheduleService = new ScheduleService();
        }
    }
}
