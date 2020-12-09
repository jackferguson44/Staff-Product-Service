using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffProductNew.Services.CustomerStockService;
using StaffProductNew.Repository;
using System;

namespace StaffProductNew.Testing
{
    [TestClass]
    public class CustomerStockTests
    {
        [TestMethod]
        public async Task GetAllProducts_ShouldOkObject()
        {
            var products = new List<Product>()
            {
                new Product {Id = 1, Ean = "Ean", CategoryId = 1, BrandId = 1, Name = "chipotle", Price = 12m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 21 },
                new Product {Id = 2, Ean = "Ean", CategoryId = 2, BrandId = 2, Name = "chip", Price = 22m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 300 }
            };
            var repo = new MockProductRespository
            {
                Data = products
            };
            var controller = new StaffProductController(repo);
            
            //Act
            var result = await controller.GetProducts();
            Assert.IsNotNull(result);
            var objResult = result as OkObjectResult;
            Assert.IsNotNull(objResult);
            var productResult = objResult.Value as IEnumerable<ProductModel>;

            
           
        }
    }
}
