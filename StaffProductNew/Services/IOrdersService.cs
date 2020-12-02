using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDto>> PutOrdersAsync();

        Task<bool> PutOrderAsync(int id);
    }
}
