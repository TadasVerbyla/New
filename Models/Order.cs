using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Order
    {
        public string comments { get; set; }
        public string delivery_address { get; set; }
        public Guid discountId { get; set; }
        public Guid id { get; set; }
        public double price { get; set; }
        public OrderStatus status { get; set; }

    }
}

