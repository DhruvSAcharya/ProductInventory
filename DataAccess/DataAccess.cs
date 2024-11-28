using Microsoft.EntityFrameworkCore;
using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataAccess : IDataAccess
    {

        private readonly AppDbContext _appDbContext;

        public DataAccess(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        public Product GetProductbyId(int id)
        {
            return _appDbContext.Products.Find(id);
        }

        public Product AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();

            return product;
        }

        public Product UpdateProductById(int id, Product product)
        {
            Product newp = _appDbContext.Products.Find(id);
            newp.Price = product.Price;
            newp.Quantity = product.Quantity;
            newp.ProductName = product.ProductName;
            newp.Description = product.Description;
            _appDbContext.Entry(newp).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return _appDbContext.Products.Find(id);
        }

        public bool DeleteProductById(int id)
        {
            var product = _appDbContext.Products.Find(id);
            if (product == null)
            {
                return false; 
            }

            _appDbContext.Remove(product);
            _appDbContext.SaveChanges();

            return true;
        }
    }
}
