using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class User
    {
        public DateTime birthdate { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public int id { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        //username not in .yaml, but sounds like it would be needed as it is in for employee
        //public string username { get; set; }
    }
}
