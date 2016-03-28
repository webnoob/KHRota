using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Data;

namespace KHRota.Services
{
    public class JobGroupService
    {
        public IEnumerable<JobGroup> Get()
        {
            return DbStorage.JobGroups;
        }

        public JobGroup GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }

        public JobGroup Update(JobGroup jobGroup)
        {
            Delete(jobGroup);
            return Insert(jobGroup);
        }

        private JobGroup Insert(JobGroup jobGroup)
        {
            if (string.IsNullOrEmpty(jobGroup.Guid))
                jobGroup.Guid = Guid.NewGuid().ToString();

            if (Get().FirstOrDefault(p => p.Guid.Equals(jobGroup.Guid, StringComparison.OrdinalIgnoreCase)) == null)
            {
                DbStorage.JobGroups.Add(jobGroup);
            }

            return jobGroup;
        }

        public void Delete(JobGroup jobGroup)
        {
            DbStorage.JobGroups.Remove(jobGroup);
        }
    }
}
