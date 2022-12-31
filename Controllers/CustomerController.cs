using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.CustomerData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerData customerData;
        public CustomerController(ICustomerData _customerData)
        {
            customerData = _customerData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetCustomers()
        {
            return Ok(customerData.GetCustomers());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            var customer = customerData.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customerData.GetCustomer(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddCustomer(CustomerDTO customer)
        {
            var createdCustomer = customerData.AddCustomer(customer);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdCustomer.id, customer);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var customerCheck = customerData.GetCustomer(id);
            if (customerCheck != null)
            {
                customerData.DeleteCustomer(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditCustomer(Guid id, CustomerDTO customer)
        {
            Customer customerCheck = customerData.GetCustomer(id);
            if (customer != null)
            {
                customerData.EditCustomer(customerCheck.id, customer);
                return Ok(customer);
            }
            return NotFound();
        }
    }
}
