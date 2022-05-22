using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<User>> Get()
        {
            var sqlQuery = "SELECT * FROM Users";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<User>(sqlQuery);
            }

        }

        public async Task<User> GetUser(int id)
        {
            var sqlQuery = "SELECT * FROM Users where userid = @UserId";

            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { UserId = id });
            }
        }

        public async Task<User> GetUserLogin(string login)
        {
            var sqlQuery = "SELECT * FROM Users where login = @UserLogin";

            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { UserLogin = login });
            }
        }

        public async Task<User> Create(User user)
        {
            var sqlQuery = "INSERT INTO Users (name, login, email, birthdate, password) VALUES (@Name, @Login, @Email, @BirthDate, @Password)";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    user.Id,
                    user.Name,
                    user.Login,
                    user.Email,
                    user.BirthDate,
                    user.Password
                });

                return user;

            }

        }

        public async Task<User> Update(int id, User user)
        {
            var sqlQuery = "UPDATE Users SET name = @Name, login = @Login, email = @Email, birthDate = @BirthDate, password = @Password WHERE userid = @Id";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    Id = id,
                    user.Name,
                    user.Login,
                    user.Email,
                    user.BirthDate,
                    user.Password
                });

                return user;
            }

        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE FROM Users WHERE userid = @UserId";

            using(var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { UserId = id});
            }
        }
    }
}