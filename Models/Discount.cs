namespace Point_of_Sale_Lab3.Models
{
    public class Discount
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        public bool percentage { get; set; }
        public DiscountType discount { get; set; }
        public string code { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        
    }
}
