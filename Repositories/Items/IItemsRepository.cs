using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(int id);
        Task<Item> CreateNewItem(Item items);
        Task<Item> UpdateItem(int id, Item item);
        Task DeleteItem(int id);
        Task<IEnumerable<Item>> GetItemsFromUser(int userid);     
    }
}