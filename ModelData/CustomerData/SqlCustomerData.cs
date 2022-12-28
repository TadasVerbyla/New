using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.CustomerData
{
    public class SqlCustomerData : ICustomerData
    {
        private PointOfSaleContext context;
        public SqlCustomerData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Customer AddCustomer(Customer customer)
        {
            customer.id = Guid.NewGuid();
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(Guid id)
        {
            context.Customers.Remove(GetCustomer(id));
            context.SaveChanges();
        }

        public Customer EditCustomer(Customer customer)
        {
            var existing = context.Customers.Find(customer.id);
            existing.firstName = customer.firstName;
            existing.lastName = customer.lastName;
            existing.birthdate = customer.birthdate;
            existing.email = customer.email;
            existing.username = customer.username;
            existing.password = customer.password;
            context.Customers.Update(existing);
            context.SaveChanges();
            return customer;
        }

        public Customer GetCustomer(Guid id)
        {
            return context.Customers.Find(id);
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
    }
}
