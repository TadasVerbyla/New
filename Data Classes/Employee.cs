using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Data_Classes
{
    public class Employee
    {
        public DateOnly birthdate { get; set; }
        public int businessId { get; set; }
        public string firstName { get; set; }
        public int id { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int shiftId { get; set; }
        public string username { get; set; }

    }
}
