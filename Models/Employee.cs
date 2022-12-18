using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Employee
    {
        public DateTime birthdate { get; set; }
        public Guid businessId { get; set; }
        public string firstName { get; set; }
        public Guid id { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int shiftId { get; set; }
        public string username { get; set; }

    }
}
