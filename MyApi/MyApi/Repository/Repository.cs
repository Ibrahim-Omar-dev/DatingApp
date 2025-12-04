using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext Context { get; }
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = Context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> filter, bool track = false)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            IQueryable<T> query = dbSet;
            if (!track)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            dbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
