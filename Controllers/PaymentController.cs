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
            try
            {
                return Ok(paymentData.GetPayments());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetPayment(Guid id)
        {
            try
            {
                var payment = paymentData.GetPayment(id);
                if (payment == null)
                {
                    return NotFound();
                }
                return Ok(paymentData.GetPayment(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")] 
        public IActionResult AddPayment(PaymentDTO payment)
        {
            try
            {
                var createdPayment = paymentData.AddPayment(payment);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPayment.id, payment);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeletePayment(Guid id)
        {
            try
            {
                var paymentCheck = paymentData.GetPayment(id);
                if (paymentCheck != null)
                {
                    paymentData.DeletePayment(id);
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
        public IActionResult PatchPayment(Guid id, PaymentDTO payment)
        {
            try
            {
                Payment paymentCheck = paymentData.GetPayment(id);
                if (payment != null)
                {
                    paymentData.PatchPayment(paymentCheck.id, payment);
                    return Ok(paymentCheck);
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
        public IActionResult EditPayment(Guid id, PaymentDTO payment)
        {
            try
            {
                Payment paymentCheck = paymentData.GetPayment(id);
                if (payment != null)
                {
                    paymentData.EditPayment(paymentCheck.id, payment);
                    return Ok(payment);
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
