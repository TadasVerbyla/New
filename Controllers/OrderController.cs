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
            return Ok(orderData.GetOrders());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetOrder(Guid id)
        {
            var order = orderData.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(orderData.GetOrder(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddOrder(OrderDTO order)
        {
            var createdOrder = orderData.AddOrder(order);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdOrder.id, order);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var orderCheck = orderData.GetOrder(id);
            if (orderCheck != null)
            {
                orderData.DeleteOrder(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditOrder(Guid id, Order order)
        {
            Order orderCheck = orderData.GetOrder(id);
            if (order != null)
            {
                order.id = orderCheck.id;
                orderData.EditOrder(order);
                return Ok(order);
            }
            return NotFound();
        }
    }
}
