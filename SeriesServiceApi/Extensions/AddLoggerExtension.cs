using Abstraction.Interfaces.Logger;
using BLL.LoggerService;

namespace SeriesServiceApi.Extensions;

internal static class AddLoggerExtension
{
    public static void AddLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}