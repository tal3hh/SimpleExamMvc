using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryLayer.Contexts;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        readonly DbSet<T> table;
        public Repository(AppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                                       Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
                                       bool enableTracking = true)
        {
            IQueryable<T> queryable = table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
                                                bool enableTracking = true)
        {
            IQueryable<T> queryable = table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }

        public T? Get(Expression<Func<T, bool>> predicate,
                      Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
                      bool enableTracking = true)
        {
            IQueryable<T> queryable = table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            return queryable.FirstOrDefault(predicate);
        }

        public List<T> GetList(Expression<Func<T, bool>>? predicate = null,
                               Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                               Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
                               bool enableTracking = true)
        {
            IQueryable<T> queryable = table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToList();
            return queryable.ToList();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> exp)
        {
            return await table.AnyAsync(exp);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> exp)
        {
            return await table.CountAsync(exp);
        }

        public async Task<T?> FindAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }

        public void Remove(T entity)
        {
            table.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable GetQueryable()
        {
            return table.AsQueryable();
        }
    }
}
