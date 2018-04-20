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
using KHRota.Classes;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FSelectHistoricSchedule : BaseForm
    {
        private readonly ScheduleService _scheduleService;

        public MeetingSchedule LoadedMeetingSchedule {get; private set; }

        public FSelectHistoricSchedule()
        {
            _scheduleService = new ScheduleService();
            
            InitializeComponent();
            LoadMeetingSchedules();
        }

        private DateTime GetDateTimeFromFileName(string fileName)
        {
            return DateTime.Parse(fileName.Split('_')[1].Replace(".db", ""));
        }

        private void LoadMeetingSchedules()
        {
            var schedules = _scheduleService.GetMeetingSchedulesStartDates().Select(Path.GetFileName).ToList();
            schedules.Sort((a, b) => DateTime.Compare(GetDateTimeFromFileName(b), GetDateTimeFromFileName(a)));
            if (!schedules.Any())
            {
                MessageBox.Show("No previous history.");
                DialogResult = DialogResult.Cancel;
                Close();
            }

            var bindingSource = new BindingSource();
            bindingSource.DataSource = schedules;
            cbMeetingSchedule.DataSource = bindingSource;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bViewSchedule_Click(object sender, EventArgs e)
        {
            LoadedMeetingSchedule = GetSelectedMeetingSchedule();
            DialogResult = DialogResult.OK;
        }

        private MeetingSchedule GetSelectedMeetingSchedule()
        {
            var fileName = cbMeetingSchedule.SelectedItem.ToString();
            return _scheduleService.LoadFromFile(fileName);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            _scheduleService.Delete(GetSelectedMeetingSchedule());
            DbService.Save();
            LoadMeetingSchedules();
        }
    }
}
