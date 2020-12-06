using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerStockService
{
    public class FakeStockService : IStockService
    {
        private readonly StockDto[] _stock =
        {
            new StockDto { Id = 1, ProductId = 1, Quantity = 2, ProductName = "Cheese"},
            new StockDto { Id = 2, ProductId = 2, Quantity = 3, ProductName = "Chipotle"}
        };
        public Task<StockDto> GetStockAsync(int id)
        {
            var stock = _stock.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(stock);
        }

        public Task<IEnumerable<StockDto>> GetStocksAsync()
        {
            var stocks = _stock.AsEnumerable();
            return Task.FromResult(stocks);
        }
    }
}
