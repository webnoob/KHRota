using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FMain : BaseForm
    {
        private readonly TestService _testService;

        public FMain()
        {
            InitializeComponent();
            _testService = new TestService();
            DbService.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var meetingSchedule =_testService.Test();
            
            string headings = meetingSchedule.ScheduledMeetings.FirstOrDefault()
                .JobAssignments.Aggregate("Date,", (current, job) => current + (job.Job.Name + ","));
            headings += "\r\n";

            var csv = headings;
            foreach (var scheduledMeeting in meetingSchedule.ScheduledMeetings)
            {
                csv += scheduledMeeting.DateTime.ToString("D") + ",";
                foreach (var job in scheduledMeeting.JobAssignments)
                    csv += job.Brother.FirstName + " " + job.Brother.LastName + "(" + job.SuitabilityFactor.Weight + ")" + ",";

                csv = csv.Substring(0, csv.Length - 1) + "\r\n";
            }

            File.WriteAllText(@"Z:\SourceCode\KHRota\KHRota\rota.csv", csv);

            //meetingSchedule.ToSerialisedXml(@"Z:\SourceCode\KHRota\KHRota\KHRota\rota.xml");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void meetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fMeeting = new FMeetings())
            {
                fMeeting.ShowDialog(this);
            }
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fJobs = new FJobs())
            {
                fJobs.ShowDialog(this);
            }
        }

        private void brothersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fBrothers = new FBrothers())
            {
                fBrothers.ShowDialog(this);
            }
        }
    }
}
