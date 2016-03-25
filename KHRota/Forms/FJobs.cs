using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FJobs : BaseForm
    {
        private readonly JobService _jobService;

        public FJobs()
        {
            _jobService = new JobService();

            InitializeComponent();
            LoadJobList(null);
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

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var job = cbEditJob.SelectedItem as Job ?? new Job();
            job.Name = tbName.Text;
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
    }
}
