using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.CustomerData
{
    public interface ICustomerData
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(Guid id);
        Customer AddCustomer(Customer customer);
        void DeleteCustomer(Guid id);
        Customer EditCustomer(Customer customer);
    }
}
