using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using LYLStudio.Service.Data.EntityFramework;

using WebApp.Models;

namespace WebApp.Services
{
    public class ProductService<T> : DataServiceBase<DataAccessResult, NorthwindEntities>, IProductService<T> where T :class
    {
        private NorthwindEntities _context;
        public override NorthwindEntities Context => _context ?? (_context = new NorthwindEntities());

        public override Action<string> Log
        {
            get => Context.Database.Log;
            set => Context.Database.Log = value;
        }

        public IEnumerable<T> SomethingSpecialMethod(Expression<Func<T, bool>> predicate)
        {
            return this.FetchList(predicate);
        }
    }
}
