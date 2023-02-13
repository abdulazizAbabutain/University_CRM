﻿using System.Linq.Expressions;

namespace University_CRM.Application.Common.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string includeProperty = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> func, string includeProperty = null);
        Task<T> GetAsync(Expression<Func<T, bool>> func);
        Task AddAsync(T item);
        Task RemoveAsync(T item);
        Task<bool> SaveAsync(CancellationToken cancellationToken);
        Task<bool> IsExists(Expression<Func<T, bool>> func, CancellationToken cancellationToken);
    }
}