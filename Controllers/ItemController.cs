using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Point_of_Sale_Lab3.ModelData.ItemData;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.Controllers
{
    [Route("PoS/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemData itemData;
        public ItemController(IItemData _itemData)
        {
            itemData = _itemData;
        }

        [HttpGet]
        [Route("PoS/[controller]")]
        public IActionResult GetItems()
        {
            return Ok(itemData.GetItems());
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetItem(Guid id)
        {
            var item = itemData.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(itemData.GetItem(id));
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddItem(Item item)
        {
            itemData.AddItem(item);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + item.id, item);
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            var itemCheck = itemData.GetItem(id);
            if (itemCheck != null)
            {
                itemData.DeleteItem(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("PoS/[controller]/{id}")]
        public IActionResult EditItem(Guid id, Item item)
        {
            Item itemCheck = itemData.GetItem(id);
            if (item != null)
            {
                item.id = itemCheck.id;
                itemData.EditItem(item);
                return Ok(item);
            }
            return NotFound();
        }
    }
}
