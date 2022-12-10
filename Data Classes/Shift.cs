using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Data_Classes
{
    internal class Shift
    {
        public int employeeId { get; set; }
        public TimeOnly endTime { get; set; }
        public TimeOnly startTime { get; set; }
        public int workdays { get; set; }
    }
}
