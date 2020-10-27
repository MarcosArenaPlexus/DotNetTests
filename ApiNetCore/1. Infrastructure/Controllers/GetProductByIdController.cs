using ApiNetCore.Dtos.Product;
using ApiNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ApiNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetProductByIdController : ControllerBase
    {
        private readonly ILogger<GetProductByIdController> _logger;
        private readonly IGetProductByIdService _getProductByIdService;

        public GetProductByIdController(IGetProductByIdService getProductByIdService)
        {
            _getProductByIdService = getProductByIdService;
        }
               
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var product = await _getProductByIdService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }
    }
}
