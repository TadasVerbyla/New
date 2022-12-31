using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class SupportRequest
    {
        public Guid id { get; set; }

        public Guid employeeId { get; set; }

        [ForeignKey("employeeId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Employee employee { get; set; }
        public Guid businessId { get; set; }

        [ForeignKey("businessId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Business business { get; set; }
        public Guid orderId { get; set; }

        [ForeignKey("orderId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Order order { get; set; }

        public Guid customerId { get; set; }
        public string issue { get; set; }
        public SupportStatus status { get; set; }
        public SupportType type { get; set; }
        public DateTime requestedOn { get; set; }
        public DateTime solvedOn { get; set; }
        
    }
}
