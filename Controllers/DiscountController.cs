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
            return Ok(discountData.GetDiscounts());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetDiscount(Guid id)
        {
            var discount = discountData.GetDiscount(id);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discountData.GetDiscount(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddDiscount(Discount discount)
        {
            discountData.AddDiscount(discount);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + discount.id, discount);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteDiscount(Guid id)
        {
            var discountCheck = discountData.GetDiscount(id);
            if (discountCheck != null)
            {
                discountData.DeleteDiscount(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditDiscount(Guid id, Discount discount)
        {
            Discount discountCheck = discountData.GetDiscount(id);
            if (discount != null)
            {
                discount.id = discountCheck.id;
                discountData.EditDiscount(discount);
                return Ok(discount);
            }
            return NotFound();
        }
    }
}
