using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class EmployeeDTO
    {
        public Guid businessId { get; set; }
        public Guid shiftId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdate { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Guid[] permissionIds { get; set; }

    }
}
