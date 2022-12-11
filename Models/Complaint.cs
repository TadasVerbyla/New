using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Complaint
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string text { get; set; }

    }
}
