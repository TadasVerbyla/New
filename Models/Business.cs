namespace Point_of_Sale_Lab3.Models
{
    public class Business
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public DateTime opening { get; set; }
        public DateTime closing { get; set; }
        public string websiteLink { get; set; }
        public string accountNumber { get; set; }
    }
}
