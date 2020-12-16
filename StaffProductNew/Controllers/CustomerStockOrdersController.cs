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

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStockOrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStockService _stockService;
        private readonly IProductRepository _productRepository;
        //Repo stuff

        public CustomerStockOrdersController(ILogger<CustomerStockOrdersController> logger, IStockService stockService,
            IProductRepository productRepository)
        {
            _logger = logger;
            _stockService = stockService;
            _productRepository = productRepository;
        }


        // GET: api/stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockDto>> GetStock(int Id)
        {
            var stock = await _stockService.GetStockAsync(Id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok (stock);
        }

        // GET: api/stocks
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetStocks()
        {
            var stocks = await _stockService.GetStocksAsync();

            return Ok(stocks);
        }

        // PUT: api/stocks/1
        [HttpPut("{id:int}")]
        public async Task <ActionResult<Product>> UpdateStock(StockDto stockChange)
        {
            var product = await _productRepository.UpdateStock(stockChange);
            return Ok(product);
        }



        //public async Task<IActionResult> UpdateStock()
        //{

        //    return Ok;
        //}


    }
}
