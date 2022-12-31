using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.BusinessData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private IBusinessData businessData;
        public BusinessController(IBusinessData _businessData)
        {
            businessData = _businessData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetBusinesses()
        {
            return Ok(businessData.GetBusinesses());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetBusiness(Guid id)
        {
            var business = businessData.GetBusiness(id);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(businessData.GetBusiness(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddBusiness(BusinessDTO business)
        {
             var createdBusiness = businessData.AddBusiness(business);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdBusiness.id, business);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteBusiness(Guid id)
        {
            var businessCheck = businessData.GetBusiness(id);
            if (businessCheck != null)
            {
                businessData.DeleteBusiness(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditBusiness(Guid id, BusinessDTO business)
        {
            Business businessCheck = businessData.GetBusiness(id);
            if (business != null)
            {
                businessData.EditBusiness(businessCheck.id, business);
                return Ok(business);
            }
            return NotFound();
        }
    }
}
