using StaffProductNew.Data;
using StaffProductNew.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffProductNew.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductAsync(int Id)
        {
            return await _productRepository.GetProduct(Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProducts();
        }
    }
}
