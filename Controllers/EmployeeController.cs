using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.EmployeeData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData employeeData;
        public EmployeeController(IEmployeeData _employeeData)
        {
            employeeData = _employeeData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = employeeData.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employeeData.GetEmployee(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.id, employee);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employeeCheck = employeeData.GetEmployee(id);
            if (employeeCheck != null)
            {
                employeeData.DeleteEmployee(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            Employee employeeCheck = employeeData.GetEmployee(id);
            if (employee != null)
            {
                employee.id = employeeCheck.id;
                employeeData.EditEmployee(employee);
                return Ok(employee);
            }
            return NotFound();
        }
    }
}
