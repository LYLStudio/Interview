using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService<Product> _productService;

        public ProductsController()
        {
            _productService = new ProductService<Product>();
        }

        // GET: api/Products
        public IQueryable<ProductInfo> GetProducts()
        {
            var datas = (_productService as ProductService<Product>)
                .FetchAll<Product>().AsQueryable()
                .Select(x=> new ProductInfo() { ProductID = x.ProductID, ProductName = x.ProductName })
                .OrderBy(o=>o.ProductID);
            return datas.AsQueryable();
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductInfo))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = (_productService as ProductService<Product>)
                .Fetch<Product>(id);
            if (product == null)
            {
                return NotFound();
            }

            var data = new ProductInfo()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName
            };

            return Ok(data);
        }
    }
}