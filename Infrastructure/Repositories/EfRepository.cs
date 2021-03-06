using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly CabsBookingDbContext _dbContext;

        public EfRepository(CabsBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<Bookings>> Details(int id)
        {

            return await _dbContext.Bookings.Include(c => c.CabTypes).Where(c=>c.CabTypesId==id).ToListAsync();
        }
    }
}