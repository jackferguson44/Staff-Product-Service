﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> UpdateStock(IEnumerable<StockDto> StockChanges)
        {
            var product = _context.Products.Where(p => p.Id == StockChanges.FirstOrDefault().ProductId).ToList();


            int x = 0;

            foreach (var item in StockChanges)
            {
                for (int i = 0; i == product.Count-1; i++)
                {
                    //if (product[x].Id > item.ProductId)
                    //{
                    //    x = 0;
                    //    break;
                    //}
                    if (product[x].Id.Equals(item.ProductId))
                    {
                        product[x].Stock = product[x].Stock - item.StockAmount;
                        if (product[x].Stock == 0)
                        {
                            product[x].InStock = false;
                        }
                        x++;
                        i--;
                        //if (product.Count() > x)
                        //{
                        //    break;
                        //}
                        //i--;
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

            //foreach(var item in StockChanges)
            //{
            //    product = _context.Products.Where(p => p.Id == StockChanges.FirstOrDefault().ProductId).ToList();
            //    if(product[x].Id.Equals(item.ProductId))
            //    {
            //        product[x].Stock = product[x].Stock - item.StockAmount;
            //    }

            // }
            // var produck = List(StockDto);
            //var amount = StockChanges.Count();
            //int x = 0;

            //var product = _context.Products.Where(p => p.Id == StockChanges.FirstOrDefault().ProductId).ToList();
            ////foreach (var item in StockChanges)
            ////{
            ////    foreach (var mc in product.Where(x => x.Id == item.ProductId))
            ////    {
            ////        mc.Stock = mc.Stock - item.StockAmount;
            ////    }
            ////}
            ////product.Where(p => p.Id == item.ProductId).ToList().
            ////{
            ////}

            //foreach(var item in StockChanges)
            //{
            //    for (int i = 0; i == product.Count - 1; i++)
            //    {
            //        //if(product[x].Id > item.ProductId)
            //        //{
            //        //    x = 0;
            //        //    break;
            //        //}
            //        if (product[x].Id.Equals(item.ProductId))
            //        {
            //            // var stockChange = item;
            //            product[x].Stock = product[x].Stock - item.StockAmount;
            //            if (product[x].Stock == 0)
            //            {
            //                product[x].InStock = false;
            //            }
            //            x++;
            //            if (product.Count() > x)
            //            {
            //                break;
            //            }
            //            //i--;
            //            //if (x + 1 > product.Count())
            //            //{
            //            //    x = 0;
            //            //    break;
            //            //}
            //        }
            //    }
            //}
            //while(StockChanges.First().ProductId != StockChanges.Last().ProductId)
            //{
            //    foreach (var item in product)
            //    {
            //        item.Stock = item.Stock - StockChanges.First().StockAmount;
            //        if (item.Stock == 0)
            //        {
            //            item.InStock = false;
            //        }
            //    }
            //    //StockChanges.First().ProductId = StockChanges.;

            //}


            //product = _context.Products.Where(p => p.Id == StockChanges.First().ProductId).ToList();




            //var product = _context.Products.Where(p => p.Id == StockChanges.First().ProductId).ToList();

            //for()

            //foreach(var item in product)
            //{
            //    item.Stock = item.Stock - StockChanges.StockAmount;

            //    if (item.Stock == 0)
            //    {
            //        item.InStock = false;
            //    }
            //}



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
