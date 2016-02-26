using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHRota.Classes;

namespace KHRota.Services
{
    public class JobService
    {
        public IEnumerable<Job> Get()
        {
            return new List<Job>
            {
                new Job
                {
                    Guid = "{265D4293-66CD-47C1-BB3B-9CFDF026B306}",
                    Name = "Sound"
                },
                new Job
                {
                    Guid = "{B09E64F6-A8BF-4B03-8D38-D38E535A9BEC}",
                    Name = "Roving Mic 1"
                },
                new Job
                {
                    Guid = "{8F2DBD04-7B8C-4635-A0E5-654A9BC75FE1}",
                    Name = "Roving Mic 2"
                },
                new Job
                {
                    Guid = "{2BF99D9E-0D6A-4562-9B02-2D3C826E16A2}",
                    Name = "Platform Mic"
                }
            };
        }

        public Job GetByGuid(string guid)
        {
            return Get().FirstOrDefault(b => b.Guid == guid);
        }
    }
}
