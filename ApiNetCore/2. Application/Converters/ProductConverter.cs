using ApiNetCore.Domain.Modules.Product.Entities;
using ApiNetCore.Dtos.Product;

namespace ApiNetCore.Converters
{
    public class ProductConverter
    {
        private static ProductConverter _instance = null;

        private ProductConverter() { }

        public static ProductConverter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductConverter();

                return _instance;
            }
        }

        public ProductDto ToDto(Product product)
        {
            if (product != null)
            {
                return new ProductDto()
                {
                    ProductId = product.Id,
                    Description = product.Description
                };
            }
            else
                return null;

        }
    }
}
