using Microsoft.EntityFrameworkCore;
using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Services.CustomerStockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StaffProductNew.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StaffProductDbContext _context;
        private readonly ILogger<ProductRepository> _logger;
       // private readonly

        public ProductRepository(StaffProductDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int Id)
        {
           Product product = _context.Products.Find(Id);
           if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        //public Product GetProduct(int Id)
        //{
        //   return _context.Products.Find(Id);
        //}

        //public IEnumerable<Product> GetProducts()
        //{
        //    return _context.Products;
        //}

        public async Task<Product> Update(Product productChanges)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productChanges.Id);
            product.Ean = productChanges.Ean;
            product.CategoryId = productChanges.CategoryId;
            product.Name = productChanges.Name;
            product.Price = productChanges.Price;
            product.InStock = productChanges.InStock;
            product.ExpectedRestock = productChanges.ExpectedRestock;
            product.Stock = productChanges.Stock;
            //var product = _context.Products.Attach(productChanges);
            //product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.SaveChanges();
            await _context.SaveChangesAsync();
            return product;
            //return await Task.FromResult(productChanges);
        }

        public async Task<Product> UpdateStock(StockDto StockChanges)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == StockChanges.ProductId);
            product.Stock = product.Stock - StockChanges.StockAmount;
            if(product.Stock == 0)
            {
                product.InStock = false;
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = await _context.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Ean = p.Ean,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    Name = p.Name,
                    Price = p.Price,
                    InStock = p.InStock,
                    ExpectedRestock = p.ExpectedRestock,
                    Stock = p.Stock
                }).ToListAsync();
                _logger.LogInformation("Retrieved");
                return products;
            }
            catch (Exception e)
            {
                _logger.LogError("L" + e.StackTrace);
            }
            return null;
           
        }


        public async Task<Product> GetProduct(int Id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();
                _logger.LogInformation("SUCCESS" + Id);
                return product;
            }
            catch(Exception e)
            {
                _logger.LogError("Failed");
            }
            return null;
           // return _context.Products.Find(Id);
           // throw new NotImplementedException();
        }

        public async Task<Product> PurchaseRequest(PurchaseRequestDto purchaseRequest)
        {
            //try
            //{
            //    await _context.Products
            //}
            return null;
        }
    }
}
