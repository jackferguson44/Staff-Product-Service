using StaffProductNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public interface ICustomerStockService
    {
        Task<Product> UpdateStock(int id);
    }
}
