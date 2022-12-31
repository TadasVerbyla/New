using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.ShiftData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private IShiftData shiftData;
        public ShiftController(IShiftData _shiftData)
        {
            shiftData = _shiftData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetShifts()
        {
            return Ok(shiftData.GetShifts());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetShift(Guid id)
        {
            var shift = shiftData.GetShift(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shiftData.GetShift(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddShift(ShiftDTO shift)
        {
            var createdShift = shiftData.AddShift(shift);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdShift.id, shift);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteShift(Guid id)
        {
            var shiftCheck = shiftData.GetShift(id);
            if (shiftCheck != null)
            {
                shiftData.DeleteShift(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditShift(Guid id, ShiftDTO shift)
        {
            Shift shiftCheck = shiftData.GetShift(id);
            if (shift != null)
            {
                shiftData.EditShift(shiftCheck.id, shift);
                return Ok(shift);
            }
            return NotFound();
        }
    }
}
