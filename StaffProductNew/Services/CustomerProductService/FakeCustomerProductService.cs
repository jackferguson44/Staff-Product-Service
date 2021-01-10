using StaffProductNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class FakeCustomerProductService : ICustomerProductService
    {
        private readonly CustomerProductDto[] _products =
        {
            new CustomerProductDto { ProductId = 1, Name = "beef jerky", Description = "crunchy", Quantity = 12,  BrandId = 1, 
                                    Brand = "butcher", CategoryId = 1, Category = "Meat",  Price = 2.33m},
            new CustomerProductDto { ProductId = 2, Name = "Nail clippers", Description = "cuts nails", Quantity = 25,  BrandId = 2,
                                    Brand = "Jerry", CategoryId = 2, Category = "Health & care",  Price = 5.99m},
        };

        public async Task<IEnumerable<CustomerProductDto>> UpdateStock(IEnumerable<Product> productChanges)
        {
            //CustomerProductDto product = _products.FirstOrDefault(p => p.ProductId == productChanges.Id);
            //product.Name = productChanges.Name;
            //product.Quantity = productChanges.Stock;
            //product.BrandId = productChanges.BrandId;
            //product.CategoryId = productChanges.CategoryId;
            //product.Price = productChanges.Price;
            //return null; //Task.FromResult(product);

            var product = productChanges.Select(p => new CustomerProductDto
            {
                ProductId = p.Id,
                Name = p.Name,
                Quantity = p.Stock,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Price = p.Price
            }).ToList();

            foreach (var item in product)
            {
                _products.Append(item);
            }

            return product;
        }
    }
}
