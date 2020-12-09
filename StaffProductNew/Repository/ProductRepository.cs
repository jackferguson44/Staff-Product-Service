using StaffProductNew.Data;
using StaffProductNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Repository
{
    public class ProductRepository : IProductRepository
    {
        private StaffProductDbContext _context;

        public ProductRepository(StaffProductDbContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int Id)
        {
           Product product = _context.Products.Find(Id);
           if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        //public Product GetProduct(int Id)
        //{
        //   return _context.Products.Find(Id);
        //}

        //public IEnumerable<Product> GetProducts()
        //{
        //    return _context.Products;
        //}

        public Product Update(Product productChanges)
        {
            var product = _context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return productChanges;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_context.Products);
           
        }


        public async Task<Product> GetProduct(int Id)
        {
            return await Task.FromResult(_context.Products.Find(Id));
            throw new NotImplementedException();
        }

        //public Product GetProduct(int id)
        //{
        //    return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        //}

        //public List<Product> GetProducts()
        //{
        //    return _context.Products.ToList();
        //}

        //public void UpdateProduct(Product product)
        //{
        //    _context.Products.Update(product);
        //}

        //public Task<Product> GetProduct(int id)
        //{
        //    return _context.
        //}

        //public Task<IEnumerable<Product>> GetProducts()
        //{
        //    return await _context.Products.ToList();
        //}

        //public void UpdateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
