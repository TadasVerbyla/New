using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.PaymentData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentData paymentData;
        public PaymentController(IPaymentData _paymentData)
        {
            paymentData = _paymentData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetPayments()
        {
            return Ok(paymentData.GetPayments());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetPayment(Guid id)
        {
            var payment = paymentData.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(paymentData.GetPayment(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")] 
        public IActionResult AddPayment(Payment payment)
        {
            paymentData.AddPayment(payment);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + payment.id, payment);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeletePayment(Guid id)
        {
            var paymentCheck = paymentData.GetPayment(id);
            if (paymentCheck != null)
            {
                paymentData.DeletePayment(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditPayment(Guid id, Payment payment)
        {
            Payment paymentCheck = paymentData.GetPayment(id);
            if (payment != null)
            {
                payment.id = paymentCheck.id;
                paymentData.EditPayment(payment);
                return Ok(payment);
            }
            return NotFound();
        }
    }
}
