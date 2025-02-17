using Microsoft.EntityFrameworkCore;
using SeriesServiceApi.DAL.EF;
using SeriesServiceApi.Interfaces.DataSourse;
using SeriesServiceApi.Models.DTO;

namespace SeriesServiceApi.DataSource
{
    public class GenericDataSourse<T> : IGenericDataSourse<T> where T : class
    {
        protected readonly StreamingServiceDbContext DbContext;

        public GenericDataSourse(StreamingServiceDbContext dbContext)
        {
            DbContext = dbContext;
        }
        protected DbSet<T> Set => DbContext.Set<T>();

        public async Task<IEnumerable<T>> GetElements()
        {
            return await Set.AsNoTracking().ToListAsync();
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
