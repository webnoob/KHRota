using System;
using System.ComponentModel;
using System.Drawing;
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

            if (_generatedMeetingSchedule != null)
            {
                lSchedule.Text = _generatedMeetingSchedule.StartDate.ToString("dd-MM-yyyy");
            }
        }

        private void bGenerateSchedule_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _generatedMeetingSchedule = null;
                SetReportPanelsVisibility();
                using (var datePicker = new FDatePicker())
                {
                    datePicker.ShowDialog(this);
                    if (datePicker.DialogResult == DialogResult.OK)
                    {
                        _generatedMeetingSchedule = _scheduleService.GenerateMeetingSchedule(_meetingService.Get(),
                            new SchedulePeriod
                            {
                                Months = Settings.Default.MonthsInAdvance,
                                StartDate = DateTime.Parse(datePicker.DateTimeResult.ToString("d"))
                            });
                    }
                }
                SetReportPanelsVisibility();
                _scheduleService.SaveGeneratedMeetingSchedule(_generatedMeetingSchedule);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetFormDefaults(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
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
            using (var form = new FDisplayReport(_generatedMeetingSchedule))
            {
                form.ShowDialog(this);
            }
        }

        private void sfDlgExportSettings_FileOk(object sender, CancelEventArgs e)
        {
            var data = DbService.ExportAsJson();
            File.WriteAllText(sfDlgExportSettings.FileName, data);
        }

        private void ofDlgImportData_FileOk(object sender, CancelEventArgs e)
        {
            var json = File.ReadAllText(ofDlgImportData.FileName);
            DbService.ImportJson(json);
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofDlgImportData.Filter = "KHRota Data File (*.json)|*.json";
            ofDlgImportData.DefaultExt = "json";
            ofDlgImportData.AddExtension = true;
            ofDlgImportData.ShowDialog(this);
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfDlgExportSettings.Filter = "KHRota Data File (*.json)|*.json";
            sfDlgExportSettings.DefaultExt = "json";
            sfDlgExportSettings.AddExtension = true;
            sfDlgExportSettings.ShowDialog(this);
        }

        private void meetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fMeeting = new FMeetings())
            {
                SetFormDefaults(fMeeting);
                fMeeting.ShowDialog(this);
            }
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fJobs = new FJobs())
            {
                SetFormDefaults(fJobs);
                fJobs.ShowDialog(this);
            }
        }

        private void brothersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fBrothers = new FBrothers())
            {
                SetFormDefaults(fBrothers);
                fBrothers.ShowDialog(this);
            }
        }

        private void bViewPreviousSchedule_Click(object sender, EventArgs e)
        {
            _generatedMeetingSchedule = null;
            SetReportPanelsVisibility();

            using (var historicSchedule = new FSelectHistoricSchedule())
            {
                if (historicSchedule.DialogResult == DialogResult.Cancel)
                    return;

                historicSchedule.ShowDialog(this);
                if (historicSchedule.DialogResult != DialogResult.OK) 
                    return;

                _generatedMeetingSchedule = historicSchedule.LoadedMeetingSchedule;
                SetReportPanelsVisibility();
            }
        }

        private void emailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FSettings())
            {
                SetFormDefaults(form);
                form.ShowDialog(this);
            }
        }
    }
}
