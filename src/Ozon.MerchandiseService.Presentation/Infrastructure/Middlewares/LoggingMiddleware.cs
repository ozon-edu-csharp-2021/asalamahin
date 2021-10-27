using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.ContentType != "application/grpc")
            {
                await LogRequest(context);  
            }
            
            if (context.Response.ContentType != "application/grpc")
            {
                await LogResponse(context); 
            }
            
            await _next(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            foreach (var header in context.Response.Headers)
            {
                {
                    _logger.LogInformation($"{header.Key}:{header.Value}");
                }
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            foreach (var header in context.Request.Headers)
            {
                _logger.LogInformation($"{header.Key}:{header.Value}");
            }
        }
    }
}