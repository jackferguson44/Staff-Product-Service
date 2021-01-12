using Microsoft.EntityFrameworkCore;
using StaffProductNew.Data;
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


        public ProductRepository(StaffProductDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


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
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> UpdateStock(IEnumerable<StockDto> StockChanges)
        {
            var product = _context.Products.Where(p => p.Id == StockChanges.FirstOrDefault().ProductId).ToList();
            int x = 0;
            foreach (var item in StockChanges)
            {
                for (int i = 0; i == product.Count-1; i++)
                {
                    if (product[x].Id.Equals(item.ProductId))
                    {
                        product[x].Stock = product[x].Stock - item.Quantity;
                        if (product[x].Stock == 0)
                        {
                            product[x].InStock = false;
                        }
                        x++;
                        i--;
                        if (x + 1 > product.Count())
                        {
                            x = 0;
                            break;
                        }
                    }
                }
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
        }
        
    }
}
