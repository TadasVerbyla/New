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
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PointOfSaleSystem;Trusted_Connection=True");
        }
    }
}
