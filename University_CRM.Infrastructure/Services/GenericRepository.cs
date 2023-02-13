using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using University_CRM.Application.Common.Interface;
using University_CRM.Infrastructure.Persistence;

namespace University_CRM.Infrastructure.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T item)
            => await _context.Set<T>().AddAsync(item);
        

        public async Task<IEnumerable<T>> GetAllAsync(string includeProperty)
        {
            var query = _context.Set<T>() as IQueryable<T>;
            if (!string.IsNullOrWhiteSpace(includeProperty))
            {
                var includes = includeProperty.Trim().Split(',');
                foreach (string include in includes)
                    query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> func, string includeProperty = null!)
        {
            var query = _context.Set<T>() as IQueryable<T>;
            if (!string.IsNullOrWhiteSpace(includeProperty))
            {
                var includes = includeProperty.Trim().Split(',');
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return await query.Where(func).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> func)
            => await _context.Set<T>().SingleOrDefaultAsync(func);

        public Task<bool> IsExistsAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken)
            => _context.Set<T>().AnyAsync(func,cancellationToken);

        public Task RemoveAsync(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
            => ( await _context.SaveChangesAsync(cancellationToken) > 0);

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
