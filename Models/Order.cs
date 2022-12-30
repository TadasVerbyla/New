using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.Models
{
    public class Order
    {
        public Guid id { get; set; }

        public Guid customerId { get; set; }

        [ForeignKey("customerId")]
        public virtual Customer customer { get; set; }
        public Guid businessId { get; set; }

        [ForeignKey("businessId")]
        public virtual Business business { get; set; }
        public Guid discountId { get; set; }

        [ForeignKey("discountId")]
        public virtual Discount discount { get; set; }
        //public List<Guid> itemIds { get; set; }

        //[ForeignKey("itemIds")]
        //public virtual List<Item> items { get; set; }

        public OrderStatus status { get; set; }
        public double price { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime completedOn { get; set; }
        public string comments { get; set; }

        public string deliveryAddress { get; set; }

    }
}

