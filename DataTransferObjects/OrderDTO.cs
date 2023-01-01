using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class OrderDTO
    {
        public Guid customerId { get; set; }
        public Guid businessId { get; set; }
        public Guid discountId { get; set; }
        public OrderStatus status { get; set; }
        public double price { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime completedOn { get; set; }
        public string comments { get; set; }
        public string deliveryAddress { get; set; }
        public Guid[] itemIds { get; set; }

    }
}

