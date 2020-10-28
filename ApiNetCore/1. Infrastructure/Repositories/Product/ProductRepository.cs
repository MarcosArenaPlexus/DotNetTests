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
      
        public Task<domain.Product> GetProductById(Guid id)
        {          
            return this.context.Products.Where(s => s.Id == id).FirstOrDefaultAsync();
        } 

        public async Task<IEnumerable<domain.Product>> GetAllProducts()
        {
             return await this.context.Products.ToListAsync();
        }  
        
        public Task<int> UpdateAsync(domain.Product entity)
        {
            throw new NotImplementedException();
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
    }
}

