using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FMeetings : BaseForm
    {
        private readonly MeetingService _meetingService;
        private readonly JobService _jobService;

        public FMeetings()
        {
            _meetingService = new MeetingService();
            _jobService = new JobService();

            InitializeComponent();
            LoadMeetingList(null);
            LoadAssignedJobs(null);
        }

        private void LoadAssignedJobs(List<Job> selectedJobs)
        {
            cblRequiredJobs.DataSource = _jobService.Get();
            cblRequiredJobs.DisplayMember = "Name";
            cblRequiredJobs.ValueMember = "Guid";

            if (selectedJobs == null)
                return;

            for (var i = 0; i < cblRequiredJobs.Items.Count; i++)
                cblRequiredJobs.SetItemChecked(i, selectedJobs.Contains(cblRequiredJobs.Items[i]));
        }

        private void LoadMeetingList(Meeting meeting)
        {
            var meetingsToBind = new List<Meeting>
            {
                new Meeting
                {
                    Name = "New Meeting ..."
                }
            };
            meetingsToBind.AddRange(_meetingService.Get());
            cbEditMeeting.DataSource = meetingsToBind;
            cbEditMeeting.DisplayMember = "Name";
            cbEditMeeting.ValueMember = "Guid";

            if (meeting != null)
                cbEditMeeting.SelectedItem = meeting;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var meeting = cbEditMeeting.SelectedItem as Meeting ?? new Meeting();
            meeting.Name = tbName.Text;
            meeting.Time = DateTime.Parse(dtpTime.Text).TimeOfDay;

            MeetingType meetingType;
            if (Enum.TryParse(cbType.Text, true, out meetingType))
                meeting.Type = meetingType;

            DayOfWeek dayOfWeek;
            if (Enum.TryParse(cbDayOfWeek.Text, true, out dayOfWeek))
                meeting.DayOfWeek = dayOfWeek;

            meeting.RequiredJobs = new List<Job>();
            meeting.RequiredJobGuids = new List<string>();

            foreach (Job job in cblRequiredJobs.CheckedItems)
            {
                meeting.RequiredJobs.Add(job);
                meeting.RequiredJobGuids.Add(job.Guid);
            }

            _meetingService.Update(meeting);
            DbService.Save();
            LoadMeetingList(meeting);
        }

        private void cbEditMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var meeting = cbEditMeeting.SelectedItem;
            LoadFormValues(meeting as Meeting);
        }

        private void LoadFormValues(Meeting meeting)
        {
            tbName.Text = meeting.Name == "New Meeting ..." ? "" : meeting.Name;
            dtpTime.Text = meeting.Time.ToString();
            cbDayOfWeek.SelectedItem = meeting.DayOfWeek.ToString();
            cbType.SelectedItem = meeting.Type.ToString();
            LoadAssignedJobs(meeting.RequiredJobs);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this meeting?", "Delete Meeting?", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            var meeting = cbEditMeeting.SelectedItem as Meeting;
            _meetingService.Delete(meeting);
            DbService.Save();
            
            LoadMeetingList(null);
        }
    }
}
