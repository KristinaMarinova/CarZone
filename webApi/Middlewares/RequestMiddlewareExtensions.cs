using Microsoft.AspNetCore.Builder;

namespace WebCarsProject.Middlewares
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestSaver(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestSaverMiddleware>();
        }
    }

}
