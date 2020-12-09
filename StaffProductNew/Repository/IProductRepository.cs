
using StaffProductNew.Data;
using StaffProductNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Repository
{
    public interface IProductRepository
    {

        Task <IEnumerable<Product>> GetProducts();

        Product GetProduct(int Id);

        Product Add(Product product);

        Product Update(Product product);

        Product Delete(int Id);

        
    }
}
