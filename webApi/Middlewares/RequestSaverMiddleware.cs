using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CarZone.Data;

namespace CarZone.Middlewares
{
    public class RequestSaverMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestSaverMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<RequestSaverMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            try
            {
                await this.next(context);
            }
            finally
            {
                var ip = context.Connection.RemoteIpAddress.ToString();
                var method = context.Request.Method;
                var path = context.Request?.Path;
                var protocol = context.Request.Protocol;
                var host = context?.Request.Host;
                var statusCode = context.Response?.StatusCode;

                this.logger.LogInformation(
                    "Request {method}, {url}, {ip}, {protocol}, {host} => {statusCode}",
                    method, path, ip, protocol, host, statusCode);
            }
        }
    }
}
