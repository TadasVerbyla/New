namespace Point_of_Sale_Lab3.Models
{
    public class OrderItem
    {
        public Guid orderId { get; set; }
        public Guid itemId { get; set; }
        public int quantity { get; set; }
    }
}
