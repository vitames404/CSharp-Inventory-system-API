using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using InventoryAPI.Models;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace InventoryAPI.Repositories
{
    public class UserItemRepostory : IUserItemRepository
    {
        public readonly string _connectionString;

        public UserItemRepostory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        // Banco IdInv UserId ItemId

        public async Task<IEnumerable<UserItem>> GetUserItems()
        {
            var sqlQuery = "select * from useritems";

            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<UserItem>(sqlQuery);
            }

        }

        public async Task<UserItem> InsertItemOnInv(UserItem ui)
        {
            var sqlQuery = "INSERT INTO useritems (userid, itemid) VALUES (@userid, @itemid)";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new {
                    ui.invid,
                    ui.userid, 
                    ui.itemid
                    });
            }

            return ui;
        }

        public async Task DeleteFrominv(int id)
        {
            var sqlQuery = "DELETE FROM useritems WHERE invid = @idinv";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { idinv = id});
            }
        }

    }
}