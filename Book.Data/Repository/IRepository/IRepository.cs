using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Book.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task AddAsync(T entity);



        T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> filterm, string? includeProperties = null, bool tracked = false);


        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        
        void Remove(T entity);
        Task RemoveAsync(T entity);


        void RemoveRange(IEnumerable<T> entities);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
