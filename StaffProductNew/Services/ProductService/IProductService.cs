using StaffProductNew.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffProductNew.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(int id);
    }
}
