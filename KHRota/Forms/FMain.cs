using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Properties;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FMain : BaseForm
    {
        private MeetingSchedule _generatedMeetingSchedule;

        private readonly ScheduleService _scheduleService;
        private readonly MeetingService _meetingService;

        public FMain()
        {
            InitializeComponent();
            
            _scheduleService = new ScheduleService();
            _meetingService = new MeetingService();
            
            DbService.Load();
            SetReportPanelsVisibility();
        }

        private void SetReportPanelsVisibility()
        {
            pScheduleGenerated.Visible = _generatedMeetingSchedule != null;
        }

        private void bGenerateSchedule_Click(object sender, EventArgs e)
        {
            _generatedMeetingSchedule = null;
            SetReportPanelsVisibility();

            _generatedMeetingSchedule = _scheduleService.GenerateMeetingSchedule(_meetingService.Get(), new SchedulePeriod
            {
                Months = Settings.Default.MonthsInAdvance,
                StartDate = DateTime.Parse("01/03/2016")
            });

            SetReportPanelsVisibility();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetFormDefaults(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
        }

        private void bEditMeetings_Click(object sender, EventArgs e)
        {
            using (var fMeeting = new FMeetings())
            {
                SetFormDefaults(fMeeting);
                fMeeting.ShowDialog(this);
            }
        }

        private void bEditJobs_Click(object sender, EventArgs e)
        {
            using (var fJobs = new FJobs())
            {
                SetFormDefaults(fJobs);
                fJobs.ShowDialog(this);
            }
        }

        private void bEditBrothers_Click(object sender, EventArgs e)
        {
            using (var fBrothers = new FBrothers())
            {
                SetFormDefaults(fBrothers);
                fBrothers.ShowDialog(this);
            }
        }

        private void bExportAsCSV_Click(object sender, EventArgs e)
        {
            sfDlgExportCsv.Filter = "CSV Files (*.csv)|*.csv";
            sfDlgExportCsv.DefaultExt = "csv";
            sfDlgExportCsv.AddExtension = true;
            sfDlgExportCsv.ShowDialog(this);
        }

        private void sfDlgExportCsv_FileOk(object sender, CancelEventArgs e)
        {
            if (_generatedMeetingSchedule == null)
                return;

            var csv = _scheduleService.GetCsv(_generatedMeetingSchedule);
            File.WriteAllText(sfDlgExportCsv.FileName, csv);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            var csv = _scheduleService.GetCsv(_generatedMeetingSchedule);
            using (var form = new FDisplayReport(csv))
            {
                form.ShowDialog(this);
            }
        }

        private void bExportData_Click(object sender, EventArgs e)
        {
            sfDlgExportSettings.Filter = "KHRota Data File (*.json)|*.json";
            sfDlgExportSettings.DefaultExt = "json";
            sfDlgExportSettings.AddExtension = true;
            sfDlgExportSettings.ShowDialog(this);
        }

        private void sfDlgExportSettings_FileOk(object sender, CancelEventArgs e)
        {
            var data = DbService.ExportAsJson();
            File.WriteAllText(sfDlgExportSettings.FileName, data);
        }

        private void bImportData_Click(object sender, EventArgs e)
        {
            ofDlgImportData.Filter = "KHRota Data File (*.json)|*.json";
            ofDlgImportData.DefaultExt = "json";
            ofDlgImportData.AddExtension = true;
            ofDlgImportData.ShowDialog(this);
        }

        private void ofDlgImportData_FileOk(object sender, CancelEventArgs e)
        {
            var json = File.ReadAllText(ofDlgImportData.FileName);
            DbService.ImportJson(json);
        }

        private void UpdateProgress(object sender, ProgressEventArgs e)
        {
            var max = Convert.ToInt32(100 * e.MaxItems);
            var currentOverallPercentage = Convert.ToInt32(e.CurrentItem * e.CurrentItemPercentage);

            /*pbGenerateSchedule.Visible = true;
            pbGenerateSchedule.Maximum = max;
            pbGenerateSchedule.Value = e.CurrentItem * 100;*/
        }
    }
}
