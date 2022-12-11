using Microsoft.EntityFrameworkCore;
using Point_of_Sale_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.DB
{
    internal class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext(): base()
        {

        }

        public DbSet<Checkout> checkouts { get; set; }
        public DbSet<Complaint> complaints { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Shift> shifts { get; set; }
        public DbSet<Support> support { get; set; }
        public DbSet<Timestamp> timestamps { get; set; }
        public DbSet<User> users { get; set; }

    }
}
