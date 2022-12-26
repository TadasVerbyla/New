using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Payment
    {
        public Guid id { get; set; }
        public Guid customerId { get; set; }
        public Guid orderId { get; set; }
        public double totalAmount { get; set; }
        public double serviceFee { get; set; }
        public Guid employeeId { get; set; }
        public double tip { get; set; }
        public string paymentMethod { get; set; }
        public DateTime payedOn { get; set; }
    }
}
