using StaffProductNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerStockService
{
    public class StockService : IStockService
    {
        private readonly HttpClient _client;
        private readonly IProductRepository _productRepo;
        public StockService(IProductRepository productRepository)
        {
            //client.BaseAddress = new System.Uri("http://localhost:44357");
            //client.Timeout = TimeSpan.FromSeconds(5);
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //_client = client;
            _productRepo = productRepository;
        }



        public async Task<StockDto> GetStockAsync(int id)
        {
            var response = await _client.GetAsync("api/stocks/" + id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var stock = await response.Content.ReadAsAsync<StockDto>();
            return stock;
        }

        public async Task<IEnumerable<StockDto>> GetStocksAsync()
        {
            //var uri = "api/stocks";

            //var response = await _client.GetAsync(uri);
            ////if (response.StatusCode == HttpStatusCode.NotFound)
            ////{
            ////    return null;
            ////}
            //response.EnsureSuccessStatusCode();
            //var orders = await response.Content.ReadAsAsync<IEnumerable<StockDto>>();
            //return orders;
            return (IEnumerable<StockDto>)await _productRepo.GetProducts();

        }
    }
}
