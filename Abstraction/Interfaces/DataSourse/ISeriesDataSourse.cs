using System.Linq.Expressions;

namespace Abstraction.Interfaces.DataSourse
{
    public interface ISeriesDataSourse : IGenericDataSourse<Series>
    {
        Task<Series?> GetSeriesWithEpisodes(Expression<Func<Series, bool>> filter);
    }
}
