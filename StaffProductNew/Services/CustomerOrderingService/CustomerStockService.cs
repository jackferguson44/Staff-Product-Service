using StaffProductNew.Data;
using StaffProductNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class CustomerStockService : ICustomerStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly HttpClient _client;

        public CustomerStockService(IProductRepository productRepository, HttpClient client)
        {
            _productRepository = productRepository;
            client.BaseAddress = new System.Uri("http://localhost:44357");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<Product> UpdateStock(int id)
        {
            //var response = await _client.GetAsync("api/stocks/" + id);
            //if (response.StatusCode == HttpStatusCode.NotFound)
            //{
            //    return null;
            //}
            //response.EnsureSuccessStatusCode();
            //var stock = await response.Content.ReadAsAsync<CustomerStockDto>();
            //return stock;
            throw new NotImplementedException();
        }
    }
}
