using StaffProductNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class FakeCustomerStockService : ICustomerStockService
    {
        public Task<Product> UpdateStock(int id)
        {
            return null;
        }
    }
}
