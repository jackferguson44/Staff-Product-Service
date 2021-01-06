using StaffProductNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerStockService
{
    public interface IStockService 
    {

        Task<StockDto> GetStockAsync(int id);

        Task<IEnumerable<StockDto>> GetStocksAsync();

        Task<Product> UpdateStock(StockDto stockChanges);
        
    }
}
