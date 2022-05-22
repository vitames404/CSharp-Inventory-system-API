using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;
using InventoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/Usuarios")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.Get();
        }

        [HttpGet("/Usuarios/{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            return await _repository.GetUser(id);
        }

        [HttpGet("/Usuarios/login/{login}")]
        public async Task<ActionResult<User>> GetUsersLogin([FromRoute] string login)
        {
            return await _repository.GetUserLogin(login);
        }


        [HttpPost("/Usuarios")]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        {
            var newUser = await _repository.Create(user);
            return newUser;
        }

        [HttpPut("/Usuarios/{id}")]
        public async Task<ActionResult<User>> PutUsers([FromRoute]int id, [FromBody] User user)
        {

                await _repository.Update(id, user);

                return user;
        }

        [HttpDelete("/Usuarios/{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }

    
    }
}