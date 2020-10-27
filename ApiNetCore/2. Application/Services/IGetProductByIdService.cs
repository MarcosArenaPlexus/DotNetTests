using ApiNetCore.Dtos.Product;
using System;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public interface IGetProductByIdService
    {
       public Task<ProductDto> GetProductByIdAsync(Guid id);
    }
}
