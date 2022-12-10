using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Data_Classes
{
    public class Order
    {
        public string comments { get; set; }
        public string delivery_address { get; set; }
        public int discountId { get; set; }
        public int id { get; set; }
        public double price { get; set; }
        public OrderStatus status { get; set; }

    }
}

