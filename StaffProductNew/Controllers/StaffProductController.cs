using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffProductNew.Data;
using StaffProductNew.Repository;
using StaffProductNew.Services;
using StaffProductNew.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StaffProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public StaffProductController(IProductRepository productRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async  Task<IActionResult>GetProduct(int Id)
        {

            var product = await _productService.GetProductAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET: api/products/5
        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }


        // PUT: api/products/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            return await _productRepository.Update(product);
        }




    }
}
