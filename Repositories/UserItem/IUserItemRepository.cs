using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public interface IUserItemRepository
    {
        Task<IEnumerable<UserItem>> GetUserItems();
        Task<UserItem> InsertItemOnInv(UserItem ui);
        Task DeleteFrominv(int id);
    }
}