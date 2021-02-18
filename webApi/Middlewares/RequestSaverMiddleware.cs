using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WebCarsProject.Data;

namespace WebCarsProject.Middlewares
{
    public class RequestSaverMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestSaverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            var request = context.Request;
            var requestInfo = new RequestSaver
            {
                Verb = request.Method,
                Path = request.Path,
                Time = DateTime.UtcNow,
                Protocol = request.Protocol
            };

            dbContext.RequestSavers.Add(requestInfo);
            dbContext.SaveChanges();

            await _next(context);
        }
    }
}
