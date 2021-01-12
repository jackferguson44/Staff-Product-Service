using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using StaffProductNew.Services.CustomerStockService;
using StaffProductNew.Repository;
using StaffProductNew.Data;
using Microsoft.AspNetCore.Authorization;
using StaffProductNew.Services.CustomerOrderingService;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerStockOrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerProductService _customerProductService;

        public CustomerStockOrdersController(ILogger<CustomerStockOrdersController> logger,
            IProductRepository productRepository, ICustomerProductService customerProductService)
        {
            _logger = logger;
            _productRepository = productRepository;
            _customerProductService = customerProductService;
        }

        // PUT: api/stocks/1
        [HttpPut("")]
    
        public async Task <ActionResult<Product>> UpdateStock(IEnumerable<StockDto> stockChange)
        {
            var product = await _productRepository.UpdateStock(stockChange);
            await Update(product);
            //for loop
            return Ok(product);
        }

     
        [HttpPost("")]
        public async Task<IEnumerable<CustomerProductDto>> Update(IEnumerable<Product> product)
        {
            return await _customerProductService.UpdateStock(product);
        }



    }
}
