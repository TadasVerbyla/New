using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PointOfSaleContext())
            {
                var complaint = new Complaint() { id = 1, orderId = 2, text = "complaint" };
                ctx.Complaints.Add(complaint);
                ctx.SaveChanges();
            }
        }
    }
}
