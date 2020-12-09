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
            Assert.IsNotNull(productResult);
            var productResultList = productResult.ToList();
            Assert.AreEqual(products.Count, productResultList.Count);
            for(int i=0; i<products.Count; i++)
            {
                Assert.AreEqual(products[i].Id, productResultList[i].Id);
                Assert.AreEqual(products[i].Ean, productResultList[i].Ean);
                Assert.AreEqual(products[i].CategoryId, productResultList[i].CategoryId);
                Assert.AreEqual(products[i].BrandId, productResultList[i].BrandId);
                Assert.AreEqual(products[i].Name, productResultList[i].Name);
                Assert.AreEqual(products[i].Price, productResultList[i].Price);
                Assert.AreEqual(products[i].InStock, productResultList[i].InStock);
                Assert.AreEqual(products[i].ExpectedRestock, productResultList[i].ExpectedRestock);
                Assert.AreEqual(products[i].Price, productResultList[i].Price);
            }  
        }

        [TestMethod]
        public async Task GetProductById_WithInvalidId_ShouldReturnNotFound()
        {
            var products = new List<Product>()
            {
                new Product {Id = 1, Ean = "Ean", CategoryId = 1, BrandId = 1, Name = "churro", Price = 12m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 21 },
                new Product {Id = 2, Ean = "Ean", CategoryId = 2, BrandId = 2, Name = "beef", Price = 22m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 300 }
            };
            var repo = new MockProductRespository
            {
                Data = products
            };
            var controller = new StaffProductController(repo);

            //Act
            var result = await controller.GetProduct(4);

            //Assert
            Assert.IsNotNull(result);
            var notResult = result as NotFoundResult;
            Assert.IsNotNull(notResult);
        }

        [TestMethod]
        public async Task GetProductById_WithValidId_ShouldOkObject()
        {
            var products = new List<Product>()
            {
                new Product {Id = 1, Ean = "Ean", CategoryId = 1, BrandId = 1, Name = "chipotle", Price = 12m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 21 },
                new Product {Id = 2, Ean = "Ean", CategoryId = 2, BrandId = 2, Name = "coriander", Price = 22m, InStock = true,
                                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 300 }
            };
            var expected = products[1];
            var repo = new MockProductRespository
            {
                Data = products
            };
            var controller = new StaffProductController(repo);

            //Act
            var result = await controller.GetProduct(expected.Id);

            //Assert
            Assert.IsNotNull(result);
            var objResult = result as OkObjectResult;
            Assert.IsNotNull(objResult);
            var productResult = objResult.Value as ProductModel;
            Assert.IsNotNull(productResult);
            Assert.AreEqual(expected.Id, productResult.Id);
            Assert.AreEqual(expected.Ean, productResult.Ean);
            Assert.AreEqual(expected.CategoryId, productResult.CategoryId);
            Assert.AreEqual(expected.BrandId, productResult.BrandId);
            Assert.AreEqual(expected.Name, productResult.Name);
            Assert.AreEqual(expected.Price, productResult.Price);
            Assert.AreEqual(expected.InStock, productResult.InStock);
            Assert.AreEqual(expected.ExpectedRestock, productResult.ExpectedRestock);
            Assert.AreEqual(expected.Stock, productResult.Stock);


        }
    }
}
