using Microsoft.EntityFrameworkCore;
using DAL.EF;

using Abstraction.Interfaces.DataSourse;


using Models.DTO;
using System.Linq.Expressions;

namespace DAL.DataSource
{
    public class GenericDataSourse<T> : IGenericDataSourse<T> where T : class
    {
        protected readonly StreamingServiceDbContext DbContext;

        public GenericDataSourse(StreamingServiceDbContext dbContext)
        {
            DbContext = dbContext;
        }
        protected DbSet<T> Set => DbContext.Set<T>();
        public IQueryable<T> GetElements(Expression<Func<T, bool>>? filter = null)
        {
            if (filter is not null)
                return Set.Where(filter).AsNoTracking();
            return Set.AsNoTracking();
        }
        public async Task<T> AddAsync(T item)
        {
            await Set.AddAsync(item);
            return item;
        }
        public Task<T> RemoveAsync(T item)
        {
            Set.Remove(item);
            return Task.FromResult(item);
        }

        public Task<T> UpdateBase(T item)
        {
            Set.Update(item);
            return Task.FromResult(item);
        }
        public async Task SaveChangesAsync() => await DbContext.SaveChangesAsync();


    }
}
