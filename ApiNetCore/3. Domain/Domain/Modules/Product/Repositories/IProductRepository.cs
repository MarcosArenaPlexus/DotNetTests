using ApiNetCore.Repositories;
using System;
using System.Threading.Tasks;
using domain = ApiNetCore.Domain.Modules.Product.Entities;

namespace ApiNetCore.Domain.Modules.Product.Repositories
{
    public interface IProductRepository : IRepositoryBase<domain.Product>
    {
        Task<domain.Product> GetProductById(Guid id);
    }
}
