using Microsoft.EntityFrameworkCore;
using DAL.DataSource;
using DAL.EF;
using Abstraction.Interfaces.DataSourse;
using System;
using System.Linq.Expressions;

namespace DAL.DataSource
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
