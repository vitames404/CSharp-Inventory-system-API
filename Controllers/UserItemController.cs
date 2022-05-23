using InventoryAPI.Models;
using InventoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class UserItemController : ControllerBase
    {
        
        private readonly IUserItemRepository _repository;

        public UserItemController(IUserItemRepository repository)
        {
            _repository = repository;
        }

        //Get all "Inventorys" from useritems database
        [HttpGet("/Inventory")]
        public async Task<IEnumerable<UserItem>> GetAllInventory()
        {
            return await _repository.GetUserItems();
        }

        //Add an item to the Inventory of a user
        [HttpPost("/Inventory")]
        public async Task<UserItem> AddtoInv([FromBody] UserItem ui)
        {
            return await _repository.InsertItemOnInv(ui);
        }

        //Remove a item from a user inventory
        [HttpDelete("/Inventory/{id}")]
        public async Task DeleteFromInv([FromRoute] int id)
        {
            await _repository.DeleteFrominv(id);
        }

    }
}