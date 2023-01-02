using System.ComponentModel.DataAnnotations.Schema;

namespace Point_of_Sale_Lab3.Models
{
    public class ItemDTO
    {
        public Guid? discountId { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public decimal? taxablePercent { get; set; }
        public float? rating { get; set; }
        public string description { get; set; }
    }
}
