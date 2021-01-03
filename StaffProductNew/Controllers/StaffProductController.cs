using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffProductNew.Data;
using StaffProductNew.Models;
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
    public class StaffProductController : ControllerBase
    {
        //private readonly StaffProductDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public StaffProductController(IProductRepository productRepository, IProductService productService)//StaffProductDbContext context)
        {
            _productRepository = productRepository;
            _productService = productService;
            //_context = context;
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        //[Authorize]
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
        //[Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }


        // PUT: api/products/1
        [HttpPut("{id:int}")]
       // [Authorize]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            return await _productRepository.Update(product);
        }




    }
}
