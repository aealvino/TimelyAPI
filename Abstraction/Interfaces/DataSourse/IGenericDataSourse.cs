using System.Linq.Expressions;

namespace Abstraction.Interfaces.DataSourse
{
    public interface IGenericDataSourse<T>
    {
        IQueryable<T> GetElements(Expression<Func<T, bool>>? filter = null);
        Task<T> AddAsync(T item);
        Task<T> RemoveAsync(T item);
        Task<T> UpdateBase(T item);
        Task SaveChangesAsync();
    }
}
