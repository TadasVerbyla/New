using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Permission
    {
        public Guid id { get; set; }

       // public List<Guid> employeeIds { get; set; }
       // [ForeignKey("employeeIds")]
       // public virtual List<Customer> employees { get; set; }

        public string name { get; set; }

    }
}
