using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetUser(int id);
        Task<User> GetUserLogin(string login);
        Task<User> Create(User user);
        Task<User> Update(int id, User user);
        Task Delete(int id);
    }
}