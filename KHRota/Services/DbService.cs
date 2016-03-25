using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHPlayer.Extensions;
using KHRota.Classes;
using KHRota.Data;
using KHRota.Properties;

namespace KHRota.Services
{
    public class DbService
    {
        public void Save()
        {
            Settings.Default.SavedMeetings = DbStorage.Meetings.ToSerializedJson();
            Settings.Default.SavedJobs = DbStorage.Jobs.ToSerializedJson();
            Settings.Default.SavedBrothers = DbStorage.Brothers.ToSerializedJson();
            Settings.Default.Save();
        }

        public void Load()
        {
            DbStorage.Meetings = Settings.Default.SavedMeetings.ToDeserialisedJson<List<Meeting>>();
            DbStorage.Jobs = Settings.Default.SavedJobs.ToDeserialisedJson<List<Job>>();
            DbStorage.Brothers = Settings.Default.SavedBrothers.ToDeserialisedJson<List<Brother>>();
        }
    }
}
