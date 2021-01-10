using StaffProductNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public interface ICustomerProductService
    {
        Task<IEnumerable<CustomerProductDto>> UpdateStock(IEnumerable<Product> productChanges);
    }
}
