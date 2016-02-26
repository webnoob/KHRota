using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRota.Extensions
{
    public static class CollectionExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var n = list.Count();

            var random = new Random();

            while (n > 1)
            {
                int rnd = random.Next(0, n);
                n--;
                T value = list[rnd];
                list[rnd] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
