using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Checkout
    {
        public Guid customerId { get; set; }
        public Guid employeeId { get; set; }
        public Guid id { get; set; }
        public string paymentMethod {get; set;}
        public double serviceFee { get; set; }
        public double tip { get; set; }
        //Do we need total amount at all?
        public double totalAmount { get; set; }
    }
}
