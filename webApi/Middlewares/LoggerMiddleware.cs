using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CarZone.Data;
using System;

namespace CarZone.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context, AppLogContext logContext)
        {
            try
            {
                await this.next(context);
            }
            finally
            {
                var log = new Log {
                    IP = context.Connection.RemoteIpAddress.ToString(),
                    Method = context.Request.Method,
                    Path = context.Request?.Path,
                    Protocol = context.Request?.Protocol,
                    Host = context.Request?.Host.ToString(),
                    StatusCode = context.Response?.StatusCode.ToString(),
                    DateTime = DateTime.Now
                };

                logContext.Attach(log);
                logContext.SaveChanges();
            }
        }
    }
}
