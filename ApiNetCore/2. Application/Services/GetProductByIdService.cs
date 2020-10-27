using ApiNetCore.Converters;
using ApiNetCore.Domain.Modules.Product.Entities;
using ApiNetCore.Domain.Modules.Product.Repositories;
using ApiNetCore.Dtos.Product;
using System;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            Product product = await  _productRepository.GetProductById(id);

            return ProductConverter.Instance.ToDto(product);

        }
    }
}
