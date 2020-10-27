using ApiNetCore.Data;
using ApiNetCore.Domain.Modules.Product.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain = ApiNetCore.Domain.Modules.Product.Entities;

namespace ApiNetCore.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiNetCoreContext context;

        public ProductRepository(ApiNetCoreContext context)
        {
            this.context = context;
        }

        public Task<int> UpdateAsync(domain.Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<domain.Product> GetProductById(Guid id)
        {          
            return this.context.Products.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> AddAsync(domain.Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<domain.Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<domain.Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        //public async Task<domain.Product> GetByIdAsync(Guid id)
        //{
        //    var sql = "SELECT * FROM PRODUCTS WHERE Id = @Id";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<domain.Product>(sql, new { Id = id });
        //        return result;
        //    }
        //}

    }
}

