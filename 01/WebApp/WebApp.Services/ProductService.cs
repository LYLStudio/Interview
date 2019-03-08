using System;
using System.Collections.Generic;

using LYLStudio.Core;
using LYLStudio.Service.Data.EntityFramework;

using WebApp.Models;

namespace WebApp.Services
{
    public class ProductService : DataServiceBase<DataAccessResult, NorthwindEntities>, IProductService        
    {
        private NorthwindEntities _context;
        public override NorthwindEntities Context => _context ?? (_context = new NorthwindEntities());

        public override Action<string> Log
        {
            get => Context.Database.Log;
            set => Context.Database.Log = value;
        }

        public IResult CreateProduct(Product product)
        {
           return Create(product);            
        }

        public IResult DeleteProduct(int id)
        {
            return Delete<Product>(o => o.ProductID == id);
        }

        public Product GetProduct(int id)
        {
            return Fetch<Product>(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return FetchAll<Product>();
        }
      
        public IResult UpdateProduct(Product product)
        {
            return Update(product);
        }
    }
}
