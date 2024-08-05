using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BGC.Common
{
    public static class DataConverter
    {
        public static string GetAge(int ageMin, int? ageMax)
        {
            if (ageMin >= 18)
            {
                return "18+";
            }
            else if (ageMax.HasValue)
            {
                return ageMin.ToString() + "-" + ageMax.ToString();
            }
            else
            {
                return ageMin.ToString() + "+";
            }
        }

        public static string GetPlayers(int minPlayers, int? maxPlayers)
        {
            return GetAge(minPlayers, maxPlayers);
        }

        public static string GetLength(int minPlayers, int? maxPlayers)
        {
            return GetAge(minPlayers, maxPlayers);
        }

        public static string GetDuration(TimeSpan? min, TimeSpan? max)
        {
            if (!min.HasValue && !max.HasValue)
            {
                return string.Empty;
            }
            else if (min.HasValue && !max.HasValue)
            {
                return "от " + GetTime(min);
            }
            else if (!min.HasValue && max.HasValue)
            {
                return "до " + GetTime(max);
            }
            else
            {
                return "от " + GetTime(min) + " до " + GetTime(max);
            }
        }

        private static string GetTime(TimeSpan? timeSpan)
        {
            if (!timeSpan.HasValue)
            {
                return string.Empty;
            }
            else if (timeSpan < TimeSpan.FromMinutes(5))
            {
                return "5 мин";
            }
            else if (timeSpan >= TimeSpan.FromMinutes(5) && timeSpan < TimeSpan.FromMinutes(60))
            {
                return timeSpan.Value.Minutes.ToString() + " мин";
            }
            else if (timeSpan.Value.Minutes == 60)
            {
                return "1 час";
            }
            else if (timeSpan >= TimeSpan.FromMinutes(60) && timeSpan < TimeSpan.FromMinutes(120))
            {
                var delta = timeSpan.Value - TimeSpan.FromMinutes(60);
                return "1 час " + delta.Minutes.ToString() + " мин";
            }
            else
            {
                return "более 2 часов";
            }

        }
    }
}
