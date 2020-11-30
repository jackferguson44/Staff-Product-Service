using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaffProductNew.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOrdersService  _ordersService;

        public OrdersController(ILogger<OrdersController> logger, IOrdersService orderService)
        {
            _logger = logger;
            _ordersService = orderService;
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int Id)
        {
            var order = await _ordersService.PostOrderAsync(Id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

    }
}
