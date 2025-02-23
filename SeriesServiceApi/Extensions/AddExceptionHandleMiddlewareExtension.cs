using SeriesServiceApi.Middlewares;

namespace SeriesServiceApi.Extensions
{
    internal static class AddExceptionHandleMiddlewareExtension
    {
        public static void AddExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
