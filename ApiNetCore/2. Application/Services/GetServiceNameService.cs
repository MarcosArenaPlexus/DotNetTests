using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Services
{
    public class GetServiceNameService : IGetServiceNameService
    {
        public string GetServiceName()
        {
            return "Hello World!";
        }
    }
}
