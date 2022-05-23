using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public class ItemsRepository : IItemsRepository{
    
        public readonly string _connectionString;

        public ItemsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var sqlQuery = "SELECT * FROM Items";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Item>(sqlQuery);
            }

        }

        public async Task<Item> GetItemById(int id)
        {
            var sqlQuery = "SELECT * FROM Items WHERE itemId = @itemId";

            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Item>(sqlQuery, new { itemId = id} );
            }

        }

        public async Task<Item> CreateNewItem(Item items)
        {
            var sqlQuery = "INSERT INTO Items (itemIcon, value, damage, defense, weigth) VALUES (@itemIcon, @value, @damage, @defense, @weigth)";
 
            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new {

                    items.itemIcon,
                    items.damage,
                    items.defense,
                    items.value,
                    items.weigth
                });

                return items;

            }
 
        }

        public async Task<Item> UpdateItem(int id, Item item)
        {
            var sqlQuery = "UPDATE Items SET itemIcon = @itemIcon, value = @value, damage = @damage, defense = @defense, weigth = @weigth WHERE itemId = @Itemid ";

            using(var connection =  new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new{
                    Itemid = id,
                    item.itemIcon,
                    item.value,
                    item.damage,
                    item.defense,
                    item.weigth
                });

                return item;
            }

        }

        public async Task DeleteItem(int id)
        {
            var sqlQuery = "DELETE FROM Items WHERE itemId = @itemid";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { itemid = id });
            }

        }

        public async Task<IEnumerable<Item>> GetItemsFromUser(int userid)
        {
            var sqlQuery = "select * from items i join useritems ui on ui.itemid = i.itemId where ui.userid = @userId";

            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Item>(sqlQuery, new {userId = userid}); 
            }
        }

    }

}