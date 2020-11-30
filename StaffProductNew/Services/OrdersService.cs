using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace StaffProductNew.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly HttpClient _client;

        public OrdersService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:44357");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }
        public async Task<OrderDto> PostOrderAsync(int id)
        {
            var response = await _client.GetAsync("api/orders/" + id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        public Task<IEnumerable<OrderDto>> PostOrdersAsync()
        {
            var uri = "api/orders/";
            throw new NotImplementedException();

        }
    }
}
