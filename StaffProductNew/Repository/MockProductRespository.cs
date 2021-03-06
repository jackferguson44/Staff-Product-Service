using StaffProductNew.Data;
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
                new Product() {Id = 1, Ean = "unsure", CategoryId = 1, BrandId = 1, Name = "candy", Price = 4.44m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 12},
                new Product() {Id = 2, Ean = "adsa", CategoryId = 2, BrandId = 2, Name = "soda", Price = 4.48m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 15}
            };
        }

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

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_productsList);
        }

        public async Task<Product> GetProduct(int Id)
        {
            return await Task.FromResult(_productsList.FirstOrDefault(p => p.Id == Id));
        }

        public Task<IEnumerable<Product>> UpdateStock(IEnumerable<StockDto> StockChanges)
        {
            throw new NotImplementedException();
        }
    }
}
