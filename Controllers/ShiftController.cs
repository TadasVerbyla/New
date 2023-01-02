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
            try
            {
                return Ok(shiftData.GetShifts());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetShift(Guid id)
        {
            try
            {
                var shift = shiftData.GetShift(id);
                if (shift == null)
                {
                    return NotFound();
                }
                return Ok(shiftData.GetShift(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddShift(ShiftDTO shift)
        {
            try
            {
                var createdShift = shiftData.AddShift(shift);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdShift.id, shift);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteShift(Guid id)
        {
            try
            {
                var shiftCheck = shiftData.GetShift(id);
                if (shiftCheck != null)
                {
                    shiftData.DeleteShift(id);
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
        public IActionResult PatchShift(Guid id, ShiftDTO shift)
        {
            try
            {
                Shift shiftCheck = shiftData.GetShift(id);
                if (shift != null)
                {
                    shiftData.PatchShift(shiftCheck.id, shift);
                    return Ok(shiftCheck);
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
        public IActionResult EditShift(Guid id, ShiftDTO shift)
        {
            try
            {
                Shift shiftCheck = shiftData.GetShift(id);
                if (shift != null)
                {
                    shiftData.EditShift(shiftCheck.id, shift);
                    return Ok(shift);
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
