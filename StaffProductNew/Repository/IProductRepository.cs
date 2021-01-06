
using StaffProductNew.Data;
using StaffProductNew.Models;
using StaffProductNew.Services.CustomerStockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Repository
{
    public interface IProductRepository
    {

        Task <IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int Id);

        Product Add(Product product);

        Task<Product> Update(Product product);

        Task<Product> UpdateStock (StockDto stockChanges);

        Product Delete(int Id);

        

        //Sends purchase request
        Task<Product> PurchaseRequest(PurchaseRequestDto purchaseRequest);


    }
}
