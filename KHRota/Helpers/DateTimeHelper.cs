using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRota.Helpers
{
    public static class DateTimeHelper
    {
        public static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            var ts = end - start;                       // Total duration
            var count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            var remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            var sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            var daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
    }
}
