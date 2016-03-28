using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRota.Classes
{
    [Serializable]
    public class ScheduledMeetingsReport
    {
        /*private Dictionary<string, List<string>> _data;

        public Dictionary<string, List<string>> Data
        {
            get { return _data ?? (_data = new Dictionary<string, List<string>>()); }
            set { _data = value; }
        }*/

        public DataRow[] Data { get; set; }

        //public ScheduledMeetingReport[] ScheduledMeetingReports { get; set; }
    }

    [Serializable]
    public class ScheduledMeetingReport
    {
        public DateTime DateTime { get; set; }

        public string[] BrothersFullNames { get; set; }
    }
}
