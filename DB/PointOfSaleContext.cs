using Microsoft.EntityFrameworkCore;
using Point_of_Sale_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Lab3.DB
{
    public class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options): base(options)
        {

        }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PointOfSaleSystem;Trusted_Connection=True");
        //}
    }
}
