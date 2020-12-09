using StaffProductNew.Data;
using StaffProductNew.Models;
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
                new Product() {Id = 3, Ean = "unsure", CategoryId = 1, BrandId = 1, Name = "curry", Price = 4.44m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 12},
                new Product() {Id = 4, Ean = "adsa", CategoryId = 2, BrandId = 2, Name = "chip", Price = 4.48m, InStock = true, ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 15}
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

        //public Product GetProduct(int Id)
        //{
        //    return _productsList.FirstOrDefault(p => p.Id == Id);
        //}

        //public IEnumerable<Product> GetProducts()
        //{
        //    return _productsList;
        //}

        public Product Update(Product productChanges)
        {
            Product product = _productsList.FirstOrDefault(p => p.Id == productChanges.Id);
            if (product != null)
            {
                product.Stock = product.Stock - productChanges.Stock;
            }
            return product;
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
