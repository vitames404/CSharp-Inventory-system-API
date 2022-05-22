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

        [HttpGet("Inventory")]
        public async Task<IEnumerable<UserItem>> GetAllInventory()
        {
            return await _repository.GetUserItems();
        }

        [HttpPost("Invetory")]
        public async Task<UserItem> AddtoInv([FromBody] UserItem ui)
        {
            return await _repository.InsertItemOnInv(ui);
        }
        
        [HttpDelete("Invetory/{id}")]
        public async Task DeleteFromInv([FromRoute] int id)
        {
            await _repository.DeleteFrominv(id);
        }

    }
}