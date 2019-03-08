using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LYLStudio.Core;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IProductService<T>
        where T : class
    {
        IEnumerable<T> GetProducts();
        T GetProduct(int id);
        IResult CreateProduct(T product);
        IResult UpdateProduct(T product);
        IResult DeleteProduct(int id);
    }    
    
    public interface IProductService : IProductService<Product>
    {

    }
}
