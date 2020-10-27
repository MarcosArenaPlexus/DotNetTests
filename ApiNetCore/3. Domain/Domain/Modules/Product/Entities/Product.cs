using System;

namespace ApiNetCore.Domain.Modules.Product.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
