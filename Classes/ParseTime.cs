using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class ParseTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        private char divider = ':';

        public ParseTime(string aTime)
        {
            var array = aTime.Split(divider);

            int.TryParse(array[0], out int hours);
            Hours = hours;

            int.TryParse(array[1], out int minutes);
            Minutes = minutes;

            int.TryParse(array[2], out int seconds);
            Seconds = seconds;
        }
    }
}
