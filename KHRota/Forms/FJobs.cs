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
    public partial class FJobs : BaseForm
    {
        private readonly JobService _jobService;
        private readonly JobGroupService _jobGroupService;

        public FJobs()
        {
            _jobService = new JobService();
            _jobGroupService = new JobGroupService();

            InitializeComponent();
            LoadJobList(null);
            LoadJobGroupList(null);
        }

        private void LoadJobList(Job job)
        {
            var jobsToBind = new List<Job>
            {
                new Job
                {
                    Name = "New Job ..."
                }
            };
            jobsToBind.AddRange(_jobService.Get());
            cbEditJob.DataSource = jobsToBind;
            cbEditJob.DisplayMember = "Name";
            cbEditJob.ValueMember = "Guid";

            if (job != null)
                cbEditJob.SelectedItem = job;
        }

        private void LoadJobGroupList(JobGroup jobGroup)
        {
            var groupsToBind = new List<JobGroup>(_jobGroupService.Get());
            cbJobGroups.DataSource = groupsToBind;
            cbJobGroups.DisplayMember = "Name";
            cbJobGroups.ValueMember = "Guid";

            if (jobGroup != null)
                cbJobGroups.SelectedItem = jobGroup;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (cbJobGroups.SelectedItem == null || string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a job name and select a job group.");
                return;
            }

            var job = cbEditJob.SelectedItem as Job ?? new Job();
            job.Name = tbName.Text;
            job.JobGroup = cbJobGroups.SelectedItem as JobGroup;
            _jobService.Update(job);
            DbService.Save();
            LoadJobList(job);
        }

        private void cbEditMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var job = cbEditJob.SelectedItem;
            LoadFormValues(job as Job);
        }

        private void LoadFormValues(Job job)
        {
            tbName.Text = job.Name == "New Job ..." ? "" : job.Name;
            LoadJobGroupList(job.JobGroup);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this job?", "Delete Job?", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            var job = cbEditJob.SelectedItem as Job;
            _jobService.Delete(job);
            DbService.Save();
            
            LoadJobList(null);
        }

        private void bAddJobGroup_Click(object sender, EventArgs e)
        {
            var point = GetScreenPoint();
            var name = Interaction.InputBox("Job Group Name?", "Job Group Name", "", point.X, point.Y);
            if (String.IsNullOrEmpty(name))
                return;

            var existingJobGroup = _jobGroupService.Get().FirstOrDefault(jg => jg.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingJobGroup != null)
                return;

            var jobGroup = _jobGroupService.Update(new JobGroup {Name = name});
            DbService.Save();
            LoadJobGroupList(jobGroup);
        }

        private void bEditGroup_Click(object sender, EventArgs e)
        {
            var point = GetScreenPoint();
            var existingJobGroup = cbJobGroups.SelectedItem as JobGroup;
            var name = Interaction.InputBox("Job Group Name?", "Job Group Name", existingJobGroup.Name, point.X, point.Y);
            if (String.IsNullOrEmpty(name))
                return;

            existingJobGroup.Name = name;
            _jobGroupService.Update(existingJobGroup);
            DbService.Save();
            LoadJobGroupList(existingJobGroup);
        }

        private Point GetScreenPoint()
        {
            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;
            var x = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2);
            var y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2);

            return new Point(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var existingJobGroup = _jobGroupService.Get().FirstOrDefault(jg => jg.Name.Equals(cbJobGroups.Text, StringComparison.OrdinalIgnoreCase));
            if (existingJobGroup == null)
                return;

            _jobGroupService.Delete(existingJobGroup);
            DbService.Save();
            LoadJobGroupList(null);
        }
    }
}
