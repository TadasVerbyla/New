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

        public Customer AddCustomer(CustomerDTO customer)
        {
            Customer _customer = new Customer();
            _customer.birthdate = customer.birthdate;
            _customer.email = customer.email;
            _customer.firstName = customer.firstName;
            _customer.lastName = customer.lastName;
            _customer.password = customer.password;
            _customer.username = customer.username;
            _customer.id = Guid.NewGuid();
            context.Customers.Add(_customer);
            context.SaveChanges();
            return _customer;
        }

        public void DeleteCustomer(Guid id)
        {
            context.Customers.Remove(GetCustomer(id));
            context.SaveChanges();
        }

        public Customer EditCustomer(Guid id, CustomerDTO customer)
        {
            var existing = context.Customers.Find(id);
            existing.firstName = customer.firstName;
            existing.lastName = customer.lastName;
            existing.birthdate = customer.birthdate;
            existing.email = customer.email;
            existing.username = customer.username;
            existing.password = customer.password;
            context.Customers.Update(existing);
            context.SaveChanges();
            return existing;
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
