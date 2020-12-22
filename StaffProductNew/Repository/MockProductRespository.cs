﻿using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Services.CustomerStockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Repository
{
    public class MockProductRespository : IProductRepository
    {
        private List<Product> _productsList;

        public List<Product> Data { get; set; }

        public MockProductRespository()
        {
            _productsList = new List<Product>()
            {
                new Product() {Id = 1, Ean = "unsure", CategoryId = 1, BrandId = 1, Name = "curry", Price = 4.44m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 12},
                new Product() {Id = 2, Ean = "adsa", CategoryId = 2, BrandId = 2, Name = "chip", Price = 4.48m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 15}
            };
        }
        public Product Add(Product product)
        {
            product.Id = _productsList.Max(p => p.Id) + 1;
            _productsList.Add(product);
            return product;
        }

        public Product Delete(int Id)
        {
            Product product = _productsList.FirstOrDefault(p => p.Id == Id);
            if(product != null)
            {
                _productsList.Remove(product);
            }
            return product;
        }

        //Update this
        public async Task<Product> Update(Product productChanges)
        {
            Product product = _productsList.FirstOrDefault(p => p.Id == productChanges.Id);
            if (product != null && product.Stock != 0)
            {
                product.Ean = productChanges.Ean;
                product.CategoryId = productChanges.CategoryId;
                product.Name = productChanges.Name;
                product.Price = productChanges.Price;
                product.InStock = productChanges.InStock;
                product.ExpectedRestock = productChanges.ExpectedRestock;
                product.Stock = productChanges.Stock;
            }
            return await Task.FromResult(product);
        }

        public async Task<Product> UpdateStock(StockDto stockChanges)
        {
            Product product = _productsList.FirstOrDefault(p => p.Id == stockChanges.ProductId);
            if (product != null && product.Stock != 0)
            {
                product.Stock = product.Stock - stockChanges.StockAmount;
            }
            return await Task.FromResult(product);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_productsList);
        }

        public async Task<Product> GetProduct(int Id)
        {
            return await Task.FromResult(_productsList.FirstOrDefault(p => p.Id == Id));
            //throw new NotImplementedException();
        }



        
    }
}
