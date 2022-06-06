using InventoryAPI.Models;
using InventoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{  
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository){
            _repository = repository;
        }

        // GET all items on the database
        [HttpGet("/Items")]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _repository.GetItems();
        }

        //Get all items from an User inventory
        [HttpGet("/UserInventory/{userid}")]
        public async Task<IEnumerable<Item>> GetItemsFromUser([FromRoute] int userid)
        {
            return await _repository.GetItemsFromUser(userid);
        }

        //Post a new item
        [HttpPost("/Items")]
        public async Task<ActionResult<Item>> CreateNewItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            return await _repository.CreateNewItem(item);
        }

        //Update an Item
        [HttpPut("/Items/{id}")]
        public async Task<ActionResult<Item>> UpdateItem([FromRoute] int id, [FromBody] Item item)
        {
            
            if (item.itemIcon == null)
            {
                return BadRequest();
            }

            return await _repository.UpdateItem(id, item);
        }

        //Delete an Item
        [HttpDelete("/Items/{id}")]
        public async Task DeleteItem([FromRoute] int id)
        {
            await _repository.DeleteItem(id);
        }

    }
}