
using Dapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class BookFoodRepository : IBookFoodRepository
    {
        private readonly IConfiguration _configuration;
        public BookFoodRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddAsync(BookFoodEntity entity)
        {
            var sql = "Insert into bookfood (UserId,FoodId,Quantity) VALUES (@UserId,@FoodId,@Quantity)";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM bookfood WHERE Id = @Id";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<BookFoodDto>> GetOrderFood(string securityCode)
        {
            var sql = "select b.Id,a.Id as UserId,f.FoodName as FoodName,f.FoodPrice as FoodPrice,f.ImageLink as ImageLink,b.Quantity as Quantity from bookfood b  inner join auth a on a.Id  = b.UserId  inner join food f on b.FoodId  = f.Id  where a.Id  = @Id";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<BookFoodDto>(sql, new { securityCode = securityCode });
                return result.ToList();
            }
        }
        public async Task<IReadOnlyList<BookFoodEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM BookFoods";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<BookFoodEntity>(sql);
                return result.ToList();
            }
        }
        public async Task<BookFoodEntity> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM BookFoods WHERE Id = @Id";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<BookFoodEntity>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(BookFoodEntity entity)
        {
            var sql = "UPDATE BookFoods SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
