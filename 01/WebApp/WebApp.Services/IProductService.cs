using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApp.Services
{
    public interface IProductService<T> where T : class
    {
        IEnumerable<T> SomethingSpecialMethod(Expression<Func<T, bool>> predicate);
    }
}
