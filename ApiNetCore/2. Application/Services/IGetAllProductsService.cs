using ApiNetCore.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public interface IGetAllProductsService
    {
        public Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
