using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PM.Web.Data.Entities;

namespace PM.Web.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntityWithId
    {
        private PMContext _pmContext;

        public BaseRepository(PMContext pmContext)
        {
            _pmContext = pmContext;
        }

        public async Task<List<T>> Get()
        {
            return await _pmContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(int id)
        {
            return await _pmContext.Set<T>().SingleAsync(i => i.Id == id);
        }

        public async Task Create(T entity)
        {
            await _pmContext.Set<T>().AddAsync(entity);
            await _pmContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _pmContext.Entry(entity).State = EntityState.Modified;
            await _pmContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await _pmContext.Set<T>().SingleAsync(i => i.Id == id);
            _pmContext.Set<T>().Remove(entity);

            await _pmContext.SaveChangesAsync();
        }

        protected IQueryable<T> Query()
        {
            return _pmContext.Set<T>();
        }
    }

    public interface IRepository<T>
    {
        Task<List<T>> Get();

        Task<T> GetOne(int id);

        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
