using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Dtos.Product
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
    }
}
