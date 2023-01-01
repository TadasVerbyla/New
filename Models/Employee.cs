using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Employee
    {
        public Guid id { get; set; }

        public Guid businessId { get; set; }

        [ForeignKey("businessId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Business business { get; set; }
        public Guid shiftId { get; set; }

        [ForeignKey("shiftId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Shift shift { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdate { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Permission> permissions { get; set; }

    }
}
