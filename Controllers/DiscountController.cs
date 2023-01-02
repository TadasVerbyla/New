using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.DiscountData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountData discountData;
        public DiscountController(IDiscountData _discountData)
        {
            discountData = _discountData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetDiscounts()
        {
            try
            {
                return Ok(discountData.GetDiscounts());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetDiscount(Guid id)
        {
            try
            {
                var discount = discountData.GetDiscount(id);
                if (discount == null)
                {
                    return NotFound();
                }
                return Ok(discountData.GetDiscount(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddDiscount(DiscountDTO discount)
        {
            try
            {
                var createdDiscount = discountData.AddDiscount(discount);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdDiscount.id, discount);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteDiscount(Guid id)
        {
            try
            {
                var discountCheck = discountData.GetDiscount(id);
                if (discountCheck != null)
                {
                    discountData.DeleteDiscount(id);
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
        public IActionResult PatchDiscount(Guid id, DiscountDTO discount)
        {
            try
            {
                Discount discountCheck = discountData.GetDiscount(id);
                if (discount != null)
                {
                    discountData.PatchDiscount(discountCheck.id, discount);
                    return Ok(discountCheck);
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
        public IActionResult EditDiscount(Guid id, DiscountDTO discount)
        {
            try
            {
                Discount discountCheck = discountData.GetDiscount(id);
                if (discount != null)
                {
                    discountData.EditDiscount(discountCheck.id, discount);
                    return Ok(discountCheck);
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
