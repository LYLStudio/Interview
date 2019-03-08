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
        private readonly IProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        // GET: api/Products
        public IQueryable<ProductInfo> GetProducts()
        {
            var datas = _productService.GetProducts()
                .AsQueryable()
                .Select(x=> new ProductInfo() { ProductID = x.ProductID, ProductName = x.ProductName })
                .OrderBy(o=>o.ProductID);
            return datas;
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductInfo))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _productService.GetProduct(id);
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

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, ProductInfo product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            var p = _productService.GetProduct(id);
            
            if(p == null)
            {
                return NotFound();
            }
            else
            {
                p.ProductName = product.ProductName;
                _productService.UpdateProduct(p);
            }
           
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductInfo))]
        public IHttpActionResult PostProduct(ProductInfo product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = new Product()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName
            };

            _productService.CreateProduct(p);

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductInfo))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);

            return Ok(new ProductInfo() { ProductID = product.ProductID, ProductName = product.ProductName });
        }      
    }
}