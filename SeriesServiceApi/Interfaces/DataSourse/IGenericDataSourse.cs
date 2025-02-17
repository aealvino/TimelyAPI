using System.Linq.Expressions;

namespace SeriesServiceApi.Interfaces.DataSourse
{
    public interface IGenericDataSourse<T>
    {
        Task <IEnumerable<T>> GetElements();
        Task<T> AddAsync(T item);
        Task<T> RemoveAsync(T item);
        Task<T> UpdateBase(T item);
        Task SaveChangesAsync();
    }
}
