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
            try
            {
                return Ok(supportRequestData.GetSupportRequests());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetSupportRequest(Guid id)
        {
            try
            {
                var supportRequest = supportRequestData.GetSupportRequest(id);
                if (supportRequest == null)
                {
                    return NotFound();
                }
                return Ok(supportRequestData.GetSupportRequest(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddSupportRequest(SupportRequestDTO supportRequest)
        {
            try
            {
                var createdSupportRequest = supportRequestData.AddSupportRequest(supportRequest);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdSupportRequest.id, supportRequest);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteSupportRequest(Guid id)
        {
            try
            {
                var supportRequestCheck = supportRequestData.GetSupportRequest(id);
                if (supportRequestCheck != null)
                {
                    supportRequestData.DeleteSupportRequest(id);
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
        public IActionResult PatchSupportRequest(Guid id, SupportRequestDTO supportRequest)
        {
            try
            {
                SupportRequest supportRequestCheck = supportRequestData.GetSupportRequest(id);
                if (supportRequest != null)
                {
                    supportRequestData.PatchSupportRequest(supportRequestCheck.id, supportRequest);
                    return Ok(supportRequestCheck);
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
        public IActionResult EditSupportRequest(Guid id, SupportRequestDTO supportRequest)
        {
            try
            {
                SupportRequest supportRequestCheck = supportRequestData.GetSupportRequest(id);
                if (supportRequest != null)
                {
                    supportRequestData.EditSupportRequest(supportRequestCheck.id, supportRequest);
                    return Ok(supportRequest);
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
