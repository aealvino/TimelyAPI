using Abstraction.Interfaces.DataSourse;
using Abstraction.Interfaces.Services;
using BLL.Services;
using SeriesServiceApi.Services;

namespace SeriesServiceApi.Extensions
{
    public static class BllServicesServiceExtension
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ISeriesService, SeriesService>();
            services.AddScoped<IEpisodesService, EpisodeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
