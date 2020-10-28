using ApiNetCore.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain = ApiNetCore.Domain.Modules.Product.Entities;

namespace ApiNetCore.Domain.Modules.Product.Repositories
{
    public interface IProductRepository : IRepositoryBase<domain.Product>
    {
        Task<domain.Product> GetProductById(Guid id);
        Task<IEnumerable<domain.Product>> GetAllProducts();
    }
}
