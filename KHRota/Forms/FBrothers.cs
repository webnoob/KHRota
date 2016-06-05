using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FBrothers : BaseForm
    {
        private readonly BrotherService _brotherService;
        private readonly JobService _jobService;
        private readonly MeetingService _meetingService;

        public FBrothers()
        {
            _brotherService = new BrotherService();
            _jobService = new JobService();
            _meetingService = new MeetingService();

            InitializeComponent();
            LoadBrotherList(null);
            LoadExludeDays(null);
            LoadAssignedJobs(null);
            LoadJobExclusions();
        }

        private void LoadAssignedJobs(List<Job> selectedJobs)
        {
            cblAssignedJobs.DataSource = _jobService.Get();
            cblAssignedJobs.DisplayMember = "Name";
            cblAssignedJobs.ValueMember = "Guid";

            if (selectedJobs == null)
                return;

            for (var i = 0; i < cblAssignedJobs.Items.Count; i++)
                cblAssignedJobs.SetItemChecked(i, selectedJobs.Contains(cblAssignedJobs.Items[i]));
        }

        private void LoadExludeDays(List<DayOfWeek> selecteDaysOfWeek)
        {
            /*cblExcludeDays.DataSource =
                Enum.GetNames(typeof (DayOfWeek))
                    .Where(dow => _meetingService.Get().Select(m => m.DayOfWeek).Contains((DayOfWeek)Enum.Parse(typeof(DayOfWeek), dow)))
                    .ToList();

            if (selecteDaysOfWeek == null)
                return;

            for (var i = 0; i < cblExcludeDays.Items.Count; i++)
            {
                DayOfWeek dayOfWeek;
                if (Enum.TryParse(cblExcludeDays.Items[i].ToString(), true, out dayOfWeek))
                    cblExcludeDays.SetItemChecked(i, selecteDaysOfWeek.Contains(dayOfWeek));
            }*/
        }

        private void LoadBrotherList(Brother brother)
        {
            var brothersToBind = new List<Brother>
            {
                new Brother
                {
                    FirstName = "New Brother ..."
                }
            };
            brothersToBind.AddRange(_brotherService.Get().OrderBy(b => b.FirstName).ThenBy(b => b.LastName));
            cbEditBrother.DataSource = brothersToBind;
            cbEditBrother.DisplayMember = "FullName";
            cbEditBrother.ValueMember = "Guid";

            if (brother != null)
                cbEditBrother.SelectedItem = brother;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var brother = GetSelectedBrother() ?? new Brother();
            brother.FirstName = tbFirstName.Text;
            brother.LastName = tbLastName.Text;
            brother.JobsPerPeriod = Convert.ToInt32(numJobsPerPeriod.Text);
            brother.StandInsPerPeriod = Convert.ToInt32(numStandInsPerPeriod.Text);
            brother.MinimumMeetingsBetweenJobs = Convert.ToInt32(numMinMeetingsBetweenJobs.Text);
            brother.AssignedJobs = _jobService.Get().Where(j => cblAssignedJobs.CheckedItems.Contains(j)).ToList();
            brother.EmailAddress = tbEmailAddress.Text;

            /*brother.ExcludeDays.Clear();
            foreach (string t in cblExcludeDays.CheckedItems)
            {
                DayOfWeek dayOfWeekEnum;
                if (Enum.TryParse(t, true, out dayOfWeekEnum))
                    brother.ExcludeDays.Add(dayOfWeekEnum);
            }*/

            _brotherService.Update(brother);
            DbService.Save();
            LoadBrotherList(null);
        }

        private void cbEditMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var brother = cbEditBrother.SelectedItem;
            LoadFormValues(brother as Brother);
        }

        private void LoadFormValues(Brother brother)
        {
            tbFirstName.Text = brother.FirstName == "New Brother ..." ? "" : brother.FirstName;
            tbLastName.Text = brother.LastName;
            tbEmailAddress.Text = brother.EmailAddress;
            if (!string.IsNullOrEmpty(brother.Guid))
            {
                numJobsPerPeriod.Text = brother.JobsPerPeriod.ToString();
                numStandInsPerPeriod.Text = brother.StandInsPerPeriod.ToString();
                numMinMeetingsBetweenJobs.Text = brother.MinimumMeetingsBetweenJobs.ToString();
            }
            LoadAssignedJobs(brother.AssignedJobs);
            LoadJobExclusions();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this job?", "Delete Job?", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            var job = GetSelectedBrother();
            _brotherService.Delete(job);
            DbService.Save();
            
            LoadBrotherList(null);
        }

        private void bAddExclusion_Click(object sender, EventArgs e)
        {
            using (var form = new FJobExclusion(GetSelectedBrother()))
            {
                form.ShowDialog(this);
                LoadJobExclusions();
            }
        }

        private void LoadJobExclusions()
        {
            lvJobExclusions.Items.Clear();
            foreach (var exclusion in GetSelectedBrother().JobExclusions)
            {
                lvJobExclusions.Items.Add(new ListViewItem(new[] {exclusion.DayOfWeek.ToString(), exclusion.Job.Name}));
            }
        }

        private Brother GetSelectedBrother()
        {
            return cbEditBrother.SelectedItem as Brother;
        }

        private void bDeleteExclusion_Click(object sender, EventArgs e)
        {
            if (lvJobExclusions.SelectedIndices.Count == 0)
                return;

            var selectedIndex = lvJobExclusions.SelectedIndices[0];
            var selectedItem = lvJobExclusions.Items[selectedIndex];
            var day = selectedItem.SubItems[0].Text;
            var job = selectedItem.SubItems[1].Text;

            GetSelectedBrother().JobExclusions.RemoveAll(ex => ex.DayOfWeek.ToString() == day && ex.Job.Name == job);
            _brotherService.Update(GetSelectedBrother());
            DbService.Save();
            LoadJobExclusions();
        }
    }
}
