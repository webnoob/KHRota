using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHPlayer.Extensions;
using KHRota.Services;
using Microsoft.Reporting.WinForms;

namespace KHRota
{
    public partial class Form1 : Form
    {
        private TestService _testService;

        public Form1()
        {
            InitializeComponent();
            _testService = new TestService();
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

            File.WriteAllText(@"Z:\SourceCode\KHRota\KHRota\KHRota\rota.csv", csv);

            //meetingSchedule.ToSerialisedXml(@"Z:\SourceCode\KHRota\KHRota\KHRota\rota.xml");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
