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
            try
            {
                return Ok(employeeData.GetEmployees());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            try
            {
                var employee = employeeData.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employeeData.GetEmployee(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var createdEmployee = employeeData.AddEmployee(employee);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdEmployee.id, employee);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            try
            {
                var employeeCheck = employeeData.GetEmployee(id);
                if (employeeCheck != null)
                {
                    employeeData.DeleteEmployee(id);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult PatchEmployee(Guid id, EmployeeDTO employee)
        {
            try
            {
                Employee employeeCheck = employeeData.GetEmployee(id);
                if (employee != null)
                {
                    employeeData.PatchEmployee(employeeCheck.id, employee);
                    return Ok(employeeCheck);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, EmployeeDTO employee)
        {
            try
            {
                Employee employeeCheck = employeeData.GetEmployee(id);
                if (employee != null)
                {
                    employeeData.EditEmployee(employeeCheck.id, employee);
                    return Ok(employee);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }
    }
}
