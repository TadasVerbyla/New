using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.PaymentData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("pos/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentData checkoutData;
        public PaymentController(IPaymentData _checkoutData)
        {
            checkoutData = _checkoutData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetCheckouts()
        {
            return Ok(checkoutData.GetPayments());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetCheckout(Guid id)
        {
            var checkout = checkoutData.GetPayment(id);
            if (checkout == null)
            {
                return NotFound();
            }
            return Ok(checkoutData.GetPayment(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")] 
        public IActionResult AddCheckout(Payment checkout)
        {
            checkoutData.AddPayment(checkout);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + checkout.id, checkout);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteCheckout(Guid id)
        {
            var checkoutCheck = checkoutData.GetPayment(id);
            if (checkoutCheck != null)
            {
                checkoutData.DeletePayment(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditCheckout(Guid id, Payment checkout)
        {
            Payment checkoutCheck = checkoutData.GetPayment(id);
            if (checkout != null)
            {
                checkout.id = checkoutCheck.id;
                checkoutData.EditPayment(checkout);
                return Ok(checkout);
            }
            return NotFound();
        }
    }
}
