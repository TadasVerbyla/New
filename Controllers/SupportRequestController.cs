using Microsoft.AspNetCore.Mvc;
using Point_of_Sale_Lab3.ModelData.SupportRequestData;
using Point_of_Sale_Lab3.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.SupportRequestData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        private ISupportRequestData supportRequestData;
        public SupportRequestController(ISupportRequestData _supportRequestData)
        {
            supportRequestData = _supportRequestData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetSupportRequests()
        {
            return Ok(supportRequestData.GetSupportRequests());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetSupportRequest(Guid id)
        {
            var supportRequest = supportRequestData.GetSupportRequest(id);
            if (supportRequest == null)
            {
                return NotFound();
            }
            return Ok(supportRequestData.GetSupportRequest(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddSupportRequest(SupportRequestDTO supportRequest)
        {
            var createdSupportRequest = supportRequestData.AddSupportRequest(supportRequest);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdSupportRequest.id, supportRequest);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteSupportRequest(Guid id)
        {
            var supportRequestCheck = supportRequestData.GetSupportRequest(id);
            if (supportRequestCheck != null)
            {
                supportRequestData.DeleteSupportRequest(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditSupportRequest(Guid id, SupportRequest supportRequest)
        {
            SupportRequest supportRequestCheck = supportRequestData.GetSupportRequest(id);
            if (supportRequest != null)
            {
                supportRequest.id = supportRequestCheck.id;
                supportRequestData.EditSupportRequest(supportRequest);
                return Ok(supportRequest);
            }
            return NotFound();
        }
    }
}
