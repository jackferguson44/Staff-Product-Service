using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services
{
    public class FakeOrdersService : IOrdersService
    {
        private readonly OrderDto[] _orders =
        {
            new OrderDto {Id = 1, ProductId = 1, Quantity = 5, When = new DateTime(2020, 12, 29, 10, 30, 50), ProductName = "Chicken", ProductEan = "Not sure", TotalPrice = 25m},
            new OrderDto {Id = 2, ProductId = 1, Quantity = 2, When = new DateTime(2020, 12, 21, 10, 30, 50), ProductName = "beef", ProductEan = "Not sure", TotalPrice = 25m}

        };


        public Task<IEnumerable<OrderDto>> PutOrdersAsync()
        {
            return null;
        }

        Task<bool> IOrdersService.PutOrderAsync(int id)
        {
            var order = _orders.FirstOrDefault(r => r.Id == id);
            // return Task.FromResult(order);
            return null;
        }
    }
}
