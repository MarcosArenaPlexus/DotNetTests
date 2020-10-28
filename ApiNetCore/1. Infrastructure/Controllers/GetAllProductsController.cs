using ApiNetCore.Dtos.Product;
using ApiNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllProductsController : ControllerBase
    {
        private readonly IGetAllProductsService _getAllProductsService;

        public GetAllProductsController(IGetAllProductsService getAllProductsService)
        {
            _getAllProductsService = getAllProductsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _getAllProductsService.GetAllProducts();

            if (products == null || !products.Any())
                return NotFound();

            return products.ToList();
        }
    }
}
