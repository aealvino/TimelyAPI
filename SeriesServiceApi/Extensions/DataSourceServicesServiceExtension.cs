using Abstraction.Interfaces.DataSourse;
using DAL.DataSource;

namespace SeriesServiceApi.Extensions
{
    public static class DataSourceServicesServiceExtension
    {
        public static void AddDataSourceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDataSourse<>), typeof(GenericDataSourse<>));
            services.AddScoped(typeof(ISeriesDataSourse), typeof(SeriesDataSourse));
        }
    }
}
