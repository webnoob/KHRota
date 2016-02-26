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

        public MeetingSchedule Test()
        {
            var meetingSchedule = _scheduleService.GenerateMeetingSchedule(_meetingService.Get(), new SchedulePeriod
            {
                Months = Settings.Default.MonthsInAdvance,
                StartDate = DateTime.Parse("01/03/2016")
            });

            return meetingSchedule;
        }
    }
}
