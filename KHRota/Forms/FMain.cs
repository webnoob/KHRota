using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Data;
using KHRota.Services;
using Microsoft.Reporting.WinForms;

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
                var dateToAdd = scheduledMeeting.DateTime.ToString("D");
                csv += dateToAdd + ",";
                foreach (var job in scheduledMeeting.JobAssignments)
                {
                    var jobToAdd = job.Brother.FirstName + " " + job.Brother.LastName + "(" +
                                   job.SuitabilityFactor.Weight + ")";
                    csv += jobToAdd + ",";
                }

                csv = csv.Substring(0, csv.Length - 1) + "\r\n";
            }
            File.WriteAllText(@"Z:\SourceCode\KHRota\KHRota\rota.csv", csv);

            
            var ds = new DataSet1();
            var dt = new DataTable();
            var tableData = csv.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var col = from cl in tableData[0].Replace(" ", "").Split(",".ToCharArray())
                select new DataColumn(cl);
            dt.Columns.AddRange(col.ToArray());

            (from st in tableData.Skip(1) select dt.Rows.Add(st.Split(",".ToCharArray()))).ToList();
            ds.Tables.Add(dt);

            var rds = new ReportDataSource("DataSet1", ds.Tables[1]);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = @"Z:\SourceCode\KHRota\KHRota\Forms\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
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

        private void FMain_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
