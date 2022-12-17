using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.CheckoutData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("pos/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private ICheckoutData checkoutData;
        public CheckoutController(ICheckoutData _checkoutData)
        {
            checkoutData = _checkoutData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetCheckouts()
        {
            return Ok(checkoutData.GetCheckouts());
        }

        [HttpGet]
        [Route("PoS/[controller]{id}")]
        public IActionResult GetCheckout(Guid id)
        {
            var checkout = checkoutData.GetCheckout(id);
            if (checkout == null)
            {
                return NotFound();
            }
            return Ok(checkoutData.GetCheckout(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")] 
        public IActionResult AddCheckout(Checkout checkout)
        {
            checkoutData.AddCheckout(checkout);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + checkout.id, checkout);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteCheckout(Guid id)
        {
            var checkoutCheck = checkoutData.GetCheckout(id);
            if (checkoutCheck != null)
            {
                checkoutData.DeleteCheckout(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditCheckout(Guid id, Checkout checkout)
        {
            var checkoutCheck = checkoutData.GetCheckout(id);
            if (checkout != null)
            {
                checkout.id = checkoutCheck.id;
                checkoutData.EditCheckout(checkout);
                return Ok(checkout);
            }
            return NotFound();
        }
    }
}
