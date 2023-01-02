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
            try
            {
                return Ok(itemData.GetItems());
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("PoS/[controller]/{id}")]
        public IActionResult GetItem(Guid id)
        {
            try
            {
                var item = itemData.GetItem(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(itemData.GetItem(id));
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("PoS/[controller]")]
        public IActionResult AddItem(ItemDTO item)
        {
            try
            {
                var createdItem = itemData.AddItem(item);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdItem.id, item);
            }
            catch (Exception e)
            {
                //TODO: Log exception internally
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("PoS/[controller]/{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            try
            {
                var itemCheck = itemData.GetItem(id);
                if (itemCheck != null)
                {
                    itemData.DeleteItem(id);
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
        public IActionResult PatchItem(Guid id, ItemDTO item)
        {
            try
            {
                Item itemCheck = itemData.GetItem(id);
                if (item != null)
                {
                    itemData.PatchItem(itemCheck.id, item);
                    return Ok(itemCheck);
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
        public IActionResult EditItem(Guid id, ItemDTO item)
        {
            try
            {
                Item itemCheck = itemData.GetItem(id);
                if (item != null)
                {
                    itemData.EditItem(itemCheck.id, item);
                    return Ok(item);
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
