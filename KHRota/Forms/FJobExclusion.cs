using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Services;
using Microsoft.VisualBasic;

namespace KHRota.Forms
{
    public partial class FJobExclusion : BaseForm
    {
        private readonly Brother _brotherToAddExclusionTo;
        
        private readonly JobService _jobService;
        private readonly MeetingService _meetingService;
        private readonly BrotherService _brotherService;

        public FJobExclusion(Brother brotherToAddExclusionTo)
        {
            _brotherToAddExclusionTo = brotherToAddExclusionTo;

            _jobService = new JobService();
            _meetingService = new MeetingService();
            _brotherService = new BrotherService();

            InitializeComponent();
            LoadJobList();
            LoadDaysOfWeek();
        }

        private void LoadDaysOfWeek()
        {
            cbDaysOfWeek.DataSource =
                Enum.GetNames(typeof(DayOfWeek))
                    .Where(dow => _meetingService.Get().Select(m => m.DayOfWeek).Contains((DayOfWeek)Enum.Parse(typeof(DayOfWeek), dow)))
                    .ToList();
        }

        private void LoadJobList()
        {
            var jobsToBind = new List<Job>(_jobService.Get());
            cbJobs.DataSource = jobsToBind;
            cbJobs.DisplayMember = "Name";
            cbJobs.ValueMember = "Guid";
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (cbJobs.SelectedItem == null || cbDaysOfWeek.SelectedItem == null)
            {
                MessageBox.Show("You must select a job and a day of week.");
                return;
            }

            _brotherToAddExclusionTo.JobExclusions.Add(new JobExclusion
            {
                DayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cbDaysOfWeek.Text),
                Job = cbJobs.SelectedItem as Job
            });

            _brotherService.Update(_brotherToAddExclusionTo);
            DbService.Save();

            DialogResult = DialogResult.OK;
        }
    }
}
