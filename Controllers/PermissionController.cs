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
            return Ok(permissionData.GetPermissions());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetPermission(Guid id)
        {
            var permission = permissionData.GetPermission(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permissionData.GetPermission(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddPermission(PermissionDTO permission)
        {
            var createdPermission = permissionData.AddPermission(permission);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPermission.id, permission);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeletePermission(Guid id)
        {
            var permissionCheck = permissionData.GetPermission(id);
            if (permissionCheck != null)
            {
                permissionData.DeletePermission(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditPermission(Guid id, Permission permission)
        {
            Permission permissionCheck = permissionData.GetPermission(id);
            if (permission != null)
            {
                permission.id = permissionCheck.id;
                permissionData.EditPermission(permission);
                return Ok(permission);
            }
            return NotFound();
        }
    }
}
