using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using KHPlayer.Extensions;
using KHRota.Classes;
using KHRota.Data;
using KHRota.Properties;

namespace KHRota.Services
{
    public class DbService
    {
        private class ExportedData
        {
            public List<Meeting> Meetings { get; set; }
            public List<Job> Jobs { get; set; }
            public List<Brother> Brothers { get; set; }
            public List<JobGroup> JobGroups { get; set; }
            public List<MeetingSchedule> ScheduleHistory { get; set; } 
        }

        public void Save()
        {
            Settings.Default.SavedMeetings = DbStorage.Meetings.ToSerializedJson();
            Settings.Default.SavedJobs = DbStorage.Jobs.ToSerializedJson();
            Settings.Default.SavedBrothers = DbStorage.Brothers.ToSerializedJson();
            Settings.Default.SavedJobGroups = DbStorage.JobGroups.ToSerializedJson();
            Settings.Default.Save();
        }

        public void Load()
        {
            DbStorage.Meetings = Settings.Default.SavedMeetings.ToDeserialisedJson<List<Meeting>>();
            DbStorage.Jobs = Settings.Default.SavedJobs.ToDeserialisedJson<List<Job>>();
            DbStorage.Brothers = Settings.Default.SavedBrothers.ToDeserialisedJson<List<Brother>>();
            DbStorage.JobGroups = Settings.Default.SavedJobGroups.ToDeserialisedJson<List<JobGroup>>();
        }

        public string ExportAsJson()
        {
            var allData = new ExportedData
            {
                Meetings = DbStorage.Meetings,
                Jobs = DbStorage.Jobs,
                Brothers = DbStorage.Brothers,
                JobGroups = DbStorage.JobGroups
            };

            return allData.ToSerializedJson();
        }

        public void ImportJson(string json)
        {
            var data = json.ToDeserialisedJson<ExportedData>();
            DbStorage.Meetings = data.Meetings;
            DbStorage.Jobs = data.Jobs;
            DbStorage.Brothers = data.Brothers;
            DbStorage.JobGroups = data.JobGroups;
            Save();
        }
    }
}
