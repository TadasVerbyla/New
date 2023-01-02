using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.OrderData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderData orderData;
        public OrderController(IOrderData _orderData)
        {
            orderData = _orderData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(orderData.GetOrders());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetOrder(Guid id)
        {
            try
            {
                var order = orderData.GetOrder(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(orderData.GetOrder(id));
            }
            catch(Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddOrder(OrderDTO order)
        {
            try
            {
                var createdOrder = orderData.AddOrder(order);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdOrder.id, order);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                var orderCheck = orderData.GetOrder(id);
                if (orderCheck != null)
                {
                    orderData.DeleteOrder(id);
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
        public IActionResult PatchOrder(Guid id, OrderDTO order)
        {
            try
            {
                Order orderCheck = orderData.GetOrder(id);
                if (order != null)
                {
                    orderData.PatchOrder(orderCheck.id, order);
                    return Ok(orderCheck);
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
        public IActionResult EditOrder(Guid id, OrderDTO order)
        {
            try
            {
                Order orderCheck = orderData.GetOrder(id);
                if (order != null)
                {
                    orderData.EditOrder(orderCheck.id, order);
                    return Ok(order);
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
