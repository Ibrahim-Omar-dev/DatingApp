using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T?> Get(Expression<Func<T, bool>> filter, bool track = false);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task DeleteAsync(T entity);
    }
}
