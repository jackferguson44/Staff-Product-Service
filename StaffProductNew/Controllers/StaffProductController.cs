﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Repository;
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
        //private readonly StaffProductDbContext _context;
        private readonly IProductRepository _productRepository;

        public StaffProductController(IProductRepository productRepository)//StaffProductDbContext context)
        {
            _productRepository = productRepository;
            //_context = context;
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetProduct(int Id)
        {
            var product = _productRepository.GetProduct(Id);
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
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        




    }
}
