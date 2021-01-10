using Newtonsoft.Json;
using StaffProductNew.Data;
using StaffProductNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class CustomerProductService : ICustomerProductService
    {
        //private readonly IProductRepository _productRepository;
        private readonly IHttpClientFactory _clientFactory;

        public CustomerProductService(IHttpClientFactory clientFactory) //IProductRepository productRepository
        {
           // _productRepository = productRepository;
            //client.BaseAddress = new System.Uri("http://localhost:44357");
            //client.Timeout = TimeSpan.FromSeconds(5);
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<CustomerProductDto>> UpdateStock(IEnumerable<Product> productChanges)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.ParseAdd("applications/json");

            var product = productChanges.Select(p => new CustomerProductDto
            {
                ProductId = p.Id,
                Name = p.Name,
                Quantity = p.Stock,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Price = p.Price
            }).ToList();

            var postTask = client.PostAsJsonAsync("https://customerproductsthamco.azurewebsites.net/api/product/", product);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return product;
            }
            return null;
        }
    }
}
