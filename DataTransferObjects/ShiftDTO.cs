using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class ShiftDTO
    {
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public int? workdays { get; set; }

    }
}
