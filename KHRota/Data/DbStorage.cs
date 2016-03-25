using System.Collections.Generic;
using KHRota.Classes;

namespace KHRota.Data
{
    public static class DbStorage
    {
        private static List<Job> _jobs;
        private static List<Meeting> _meetings;
        private static List<Brother> _brothers;

        public static List<Job> Jobs
        {
            get { return _jobs ?? (_jobs = new List<Job>()); }
            set { _jobs = value; }
        }

        public static List<Meeting> Meetings
        {
            get { return _meetings ?? (_meetings = new List<Meeting>()); }
            set { _meetings = value; }
        }

        public static List<Brother> Brothers
        {
            get { return _brothers ?? (_brothers = new List<Brother>()); }
            set { _brothers = value; }
        }
    }
}
