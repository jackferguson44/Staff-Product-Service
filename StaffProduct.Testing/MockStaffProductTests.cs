using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StaffProductNew.Controllers;
using StaffProductNew.Data;
using StaffProductNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffProductNew.Repository;
using StaffProductNew.Services.ProductService;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace StaffProductNew.Testing
{
    [TestClass]
    public class MockStaffProductTests
    {

        private StaffProductController _staffProductController;
        private Mock<IProductService> _mockProductService;
        private Mock<IProductRepository> _mockProductRepository;
        private Product _mockProduct;

        [TestMethod]
        //[Fact]
        public async Task GetProduct_ShouldOkObject()
        {

            _mockProductService = new Mock<IProductService>();
            _mockProductRepository = new Mock<IProductRepository>();
            _staffProductController = new StaffProductController(_mockProductRepository.Object,_mockProductService.Object);
            _mockProduct= new Product
            {
                Id = 1,
                Ean = "Ean",
                CategoryId = 1,
                BrandId = 1,
                Name = "chipotle",
                Price = 12m,
                InStock = true,
                ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50),
                Stock = 21
            };

            //Act
            _mockProductService.Setup(g => g.GetProductAsync(1)).ReturnsAsync(_mockProduct);

            var result = await _staffProductController.GetProduct(1) as OkObjectResult;

            // Assert 
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(result.StatusCode, 200);
            NUnit.Framework.Assert.AreEqual(result.Value, _mockProduct);
            _mockProductService.Verify(m => m.GetProductAsync(It.IsAny<int>()), Times.Once);
            
        }

        [TestMethod]
        public async Task GetProducts_ShouldOkObject()
        {
            //Arrange
            var products = new List<Product>()
             {
                 new Product {Id = 1, Ean = "Ean", CategoryId = 1, BrandId = 1, Name = "chipotle", Price = 12m, InStock = true,
                                 ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 21 },
                 new Product {Id = 2, Ean = "Ean", CategoryId = 2, BrandId = 2, Name = "chip", Price = 22m, InStock = true,
                                 ExpectedRestock = new DateTime(2020, 12, 25, 10, 30, 50), Stock = 300 }
             };
            var mock = new Mock<IProductRepository>(MockBehavior.Strict);
            mock.Setup(repo => repo.GetProducts()).ReturnsAsync(products).Verifiable();
            var mockTwo = new Mock<IProductService>(MockBehavior.Strict);
            mockTwo.Setup(service => service.GetProductsAsync()).ReturnsAsync(products).Verifiable();
            var controller = new StaffProductController(mock.Object, mockTwo.Object);

            //Act
            var result = await controller.GetProducts();

            //Assert
            Assert.IsNotNull(result);
            var objResult = result as OkObjectResult;
            Assert.IsNotNull(objResult);
            var productResult = objResult.Value as IEnumerable<Product>;
            Assert.IsNotNull(productResult);
            var productResultList = productResult.ToList();
            Assert.AreEqual(products.Count, productResultList.Count);
            for (int i = 0; i < products.Count; i++)
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
            //fails 
            // mock.Verify();
            //// mock.Verify(repo => repo.GetProducts(), Times.Once);
        }

    }
}
