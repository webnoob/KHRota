using System;
using System.Collections.Generic;
using System.Linq;
using KHRota.Classes;
using KHRota.Data;

namespace KHRota.Services
{
    public class BrotherService
    {
        private readonly JobService _jobService;

        public BrotherService()
        {
            _jobService = new JobService();
        }

        public IEnumerable<Brother> Get()
        {
            #region fake data
            /*return new List<Brother>
            {
                new Brother
                {
                    Guid = "{B2FE5050-EDC9-41B3-B407-49E7F7D439C7}",
                    FirstName = "Stephen",
                    LastName = "Ward",
                    JobsPerPeriod = 4,
                    MinimumMeetingsBetweenJobs = 2,
                    StandInsPerPeriod = 2,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{A8534932-0BEE-4501-B173-A4DC9CFB6D0B}",
                    FirstName = "Sam",
                    LastName = "Cady",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{B2FE5050-EDC9-41B3-B407-49E7F7D439C9}",
                    FirstName = "Test",
                    LastName = "Man",
                    JobsPerPeriod = 4,
                    MinimumMeetingsBetweenJobs = 3,
                    StandInsPerPeriod = 1,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76EEE}",
                    FirstName = "Allan",
                    LastName = "Gaunt",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E01}",
                    FirstName = "Allan",
                    LastName = "Gaunt1",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E02}",
                    FirstName = "Allan",
                    LastName = "Gaunt2",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E03}",
                    FirstName = "Allan",
                    LastName = "Gaunt3",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E04}",
                    FirstName = "Allan",
                    LastName = "Gaunt4",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E05}",
                    FirstName = "Allan",
                    LastName = "Gaunt5",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E06}",
                    FirstName = "Allan",
                    LastName = "Gaunt6",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E07}",
                    FirstName = "Allan",
                    LastName = "Gaunt7",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E08}",
                    FirstName = "Allan",
                    LastName = "Gaunt8",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E09}",
                    FirstName = "Allan",
                    LastName = "Gaunt9",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E10}",
                    FirstName = "Allan",
                    LastName = "Gaunt10",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E11}",
                    FirstName = "Allan",
                    LastName = "Gaunt11",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                },
                new Brother
                {
                    Guid = "{4F80A3E4-7B40-4A79-9A2A-FC80A7D76E12}",
                    FirstName = "Allan",
                    LastName = "Gaunt12",
                    JobsPerPeriod = 12,
                    MinimumMeetingsBetweenJobs = 1,
                    StandInsPerPeriod = 99,
                    AssignedJobs =
                        _jobService.Get()
                            .Where(j => new[] {"Sound", "Platform Mic", "Roving Mic 1", "Roving Mic 2"}.Contains(j.Name))
                            .ToList()
                }
            };*/
            #endregion

            return DbStorage.Brothers;
        }

        public Brother GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }

        public bool AllowedToDoJob(Brother brother, Job job)
        {
            return brother.AssignedJobs.Any(j => j.Guid == job.Guid);
        }

        public void Update(Brother brother)
        {
            Delete(brother);
            Insert(brother);
        }

        private Brother Insert(Brother brother)
        {
            if (string.IsNullOrEmpty(brother.Guid))
                brother.Guid = Guid.NewGuid().ToString();

            if (Get().FirstOrDefault(p => p.Guid.Equals(brother.Guid, StringComparison.OrdinalIgnoreCase)) == null)
            {
                DbStorage.Brothers.Add(brother);
            }

            return brother;
        }

        public void Delete(Brother brother)
        {
            DbStorage.Brothers.Remove(brother);
        }
    }
}
