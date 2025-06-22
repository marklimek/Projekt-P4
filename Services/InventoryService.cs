using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class InventoryService : IDisposable
    {
        private readonly WarehouseDbContext _db = new();

        public List<Product> GetAllProducts(){
            return _db.Products.ToList();
        }

        public void AddProduct(Product product){
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product) { 
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void RemoveProduct(Product product){
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public void Dispose(){
            _db.Dispose();
        }
    }
}
