using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffProductNew.Services.PurchaseRequestStockService
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly HttpClient _client;
       // private readonly IProductRepository _productRepo;
        public PurchaseRequestService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:44357");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            //_productRepo = productRepository;
        }
        public async Task<PurchaseRequestDto> CreatePurchaseRequest(int id, int productId, int purchaseAmount)
        {
            var uri = "api/purchaserequest";
            var response = await _client.GetAsync(uri);
            var purchaseRequest = new PurchaseRequestDto()
            {
                Id = id,
                ProductId = productId,
                purchaseAmount = purchaseAmount
            };
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return purchaseRequest;
        }
    }
}
