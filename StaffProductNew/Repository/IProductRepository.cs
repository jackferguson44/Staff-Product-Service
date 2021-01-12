using StaffProductNew.Data;
using StaffProductNew.Services.CustomerStockService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffProductNew.Repository
{
    public interface IProductRepository
    {

        Task <IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int Id);


        Task<Product> Update(Product product);


        Task<IEnumerable<Product>> UpdateStock(IEnumerable<StockDto> StockChanges);



    }
}
