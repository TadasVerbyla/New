using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Data_Classes
{
    public class Timestamp
    {
        //Don't know if this should even exist. Theoretically used for date and time but that is useless in C#
        public int date { get; set; }
        public int day { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int month { get; set; }
        public int nanos { get; set; }
        public int seconds { get; set; }
        public Int64 time { get; set; }
        public int timezoneOffset { get; set; }
        public int year { get; set; }

    }
}
