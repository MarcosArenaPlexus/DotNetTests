using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetServiceNameController : ControllerBase
    {       
        private readonly ILogger<GetServiceNameController> _logger;

        public GetServiceNameController(ILogger<GetServiceNameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetServiceName()
        {
            return "Hello World!";
        }
    }
}
