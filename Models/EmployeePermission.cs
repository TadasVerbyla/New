
using System.ComponentModel.DataAnnotations;

namespace Point_of_Sale_Lab3.Models
{
    public class EmployeePermission
    {
        [Key]
        public Guid employeeId { get; set; }
        public Permission permission { get; set; }
    }
}
