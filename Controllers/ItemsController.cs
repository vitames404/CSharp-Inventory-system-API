using InventoryAPI.Models;
using InventoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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

        [HttpGet("/Items")]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _repository.GetItems();
        }

        [HttpGet("/UserInventory/{userid}")]
        public async Task<IEnumerable<Item>> GetItemsFromUser([FromRoute] int userid)
        {
            return await _repository.GetItemsFromUser(userid);
        }

        [HttpPost("/Items")]
        public async Task<Item> CreateNewItem([FromBody] Item item)
        {
            return await _repository.CreateNewItem(item);
        }

        [HttpPut("/Items/{id}")]
        public async Task<Item> UpdateItem([FromRoute] int id, [FromBody] Item item)
        {
            return await _repository.UpdateItem(id, item);
        }

        [HttpDelete("/Items/{id}")]
        public async Task DeleteItem([FromRoute] int id)
        {
            await _repository.DeleteItem(id);
        }

    }
}