using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStockOrdersController : ControllerBase
    {
        private readonly ILogger _logger;

        public CustomerStockOrdersController(ILogger<CustomerStockOrdersController> logger)
        {
            _logger = logger;
        }

    }
}
