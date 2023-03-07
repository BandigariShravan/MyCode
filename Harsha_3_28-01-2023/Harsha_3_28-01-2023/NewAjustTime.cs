using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harsha_3_28_01_2023
{
    public class NewAjustTime
    {
        public static string NewTime(string TimeStamp,int hours,int minutes,int seconds)
        {
            string[] parts = TimeStamp.Split(':');
            int secs = int.Parse(parts[2]);
            secs = secs + seconds;
            int mins = int.Parse(parts[1]) + minutes + (secs / 60);            
            int hrs = int.Parse(parts[0]) + hours +(mins / 60);
            secs=secs %60;
            mins = mins %60;
            hrs = hrs % 24;
            return (hrs, mins, secs).ToString();
        }
    }
}
