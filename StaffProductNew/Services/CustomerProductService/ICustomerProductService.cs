using StaffProductNew.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public interface ICustomerProductService
    {
        Task<IEnumerable<CustomerProductDto>> UpdateStock(IEnumerable<Product> productChanges);
    }
}
