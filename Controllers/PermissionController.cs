using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.PermissionData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private IPermissionData permissionData;
        public PermissionController(IPermissionData _permissionData)
        {
            permissionData = _permissionData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetPermissions()
        {
            try
            {
                return Ok(permissionData.GetPermissions());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetPermission(Guid id)
        {
            try
            {
                var permission = permissionData.GetPermission(id);
                if (permission == null)
                {
                    return NotFound();
                }
                return Ok(permissionData.GetPermission(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddPermission(PermissionDTO permission)
        {
            try
            {
                var createdPermission = permissionData.AddPermission(permission);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPermission.id, permission);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeletePermission(Guid id)
        {
            try
            {
                var permissionCheck = permissionData.GetPermission(id);
                if (permissionCheck != null)
                {
                    permissionData.DeletePermission(id);
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
        public IActionResult EditPermission(Guid id, PermissionDTO permission)
        {
            try
            {
                Permission permissionCheck = permissionData.GetPermission(id);
                if (permission != null)
                {
                    permissionData.EditPermission(permissionCheck.id, permission);
                    return Ok(permission);
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
