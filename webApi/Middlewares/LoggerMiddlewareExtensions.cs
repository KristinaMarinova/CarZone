using Microsoft.AspNetCore.Builder;

namespace CarZone.Middlewares
{
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestSaver(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }

}
