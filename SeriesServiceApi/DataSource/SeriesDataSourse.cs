using Microsoft.EntityFrameworkCore;
using SeriesServiceApi.Controllers;
using SeriesServiceApi.DAL.EF;
using SeriesServiceApi.Interfaces.DataSourse;
using System;
using System.Linq.Expressions;

namespace SeriesServiceApi.DataSource
{
    public class SeriesDataSourse : GenericDataSourse<Series>, ISeriesDataSourse
    {
        public SeriesDataSourse(StreamingServiceDbContext dbContext) : base(dbContext) { }
        public async Task<Series?> GetSeriesWithEpisodes(Expression<Func<Series, bool>> filter)
        {
            return await Set.Include(x => x.Episodes).FirstOrDefaultAsync(filter);
        }
    }
}
