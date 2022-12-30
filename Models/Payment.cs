using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Payment
    {
        public Guid id { get; set; }

        public Guid customerId { get; set; }

        [ForeignKey("customerId")]
        public virtual Customer customer { get; set; }

        public Guid orderId { get; set; }

        [ForeignKey("orderId")]
        public virtual Order order { get; set; }
        public Guid employeeId { get; set; }

        [ForeignKey("employeeId")]
        public virtual Employee employee { get; set; }

        public double totalAmount { get; set; }
        public double serviceFee { get; set; }
        public double tip { get; set; }
        public string paymentMethod { get; set; }
        public DateTime payedOn { get; set; }
    }
}
