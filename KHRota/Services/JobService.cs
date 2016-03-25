using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Data;

namespace KHRota.Services
{
    public class JobService
    {
        public IEnumerable<Job> Get()
        {
            return DbStorage.Jobs;
        }

        public Job GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }

        public void Update(Job job)
        {
            Delete(job);
            Insert(job);
        }

        private Job Insert(Job job)
        {
            if (string.IsNullOrEmpty(job.Guid))
                job.Guid = Guid.NewGuid().ToString();

            if (Get().FirstOrDefault(p => p.Guid.Equals(job.Guid, StringComparison.OrdinalIgnoreCase)) == null)
            {
                DbStorage.Jobs.Add(job);
            }

            return job;
        }

        public void Delete(Job job)
        {
            DbStorage.Jobs.Remove(job);
        }
    }
}
