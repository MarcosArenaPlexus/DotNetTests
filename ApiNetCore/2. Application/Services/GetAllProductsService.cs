using ApiNetCore.Converters;
using ApiNetCore.Domain.Modules.Product.Repositories;
using ApiNetCore.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain = ApiNetCore.Domain.Modules.Product.Entities;

namespace ApiNetCore.Services
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<domain.Product> products = await _productRepository.GetAllProducts();

            return ProductConverter.Instance.ToDtos(products);
        }
    }
}
