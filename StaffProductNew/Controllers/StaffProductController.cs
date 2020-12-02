using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Services;
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
        private readonly StaffProductDbContext _context;

        public StaffProductController(StaffProductDbContext context)
        {
            _context = context;
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int Id)
        {
            var product = await _context.Products
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Ean = p.Ean,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    Name = p.Name,
                    Price = p.Price,
                    InStock = p.InStock,
                    ExpectedRestock = p.ExpectedRestock

                }).FirstOrDefaultAsync(p => p.Id == Id);
           
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // GET: api/products/5
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Ean = p.Ean,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    Name = p.Name,
                    Price = p.Price,
                    InStock = p.InStock,
                    ExpectedRestock = p.ExpectedRestock
                })
                .ToListAsync();

            return products;
        }




        //// GET: api/orders/5
        ////[HttpGet("{id}")]
        //public async Task<ActionResult<OrderDto>> CreateOrder(int Id)
        //{
        //    var order = await _ordersService.PostOrderAsync(Id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    return order;
        //}


    }
}
