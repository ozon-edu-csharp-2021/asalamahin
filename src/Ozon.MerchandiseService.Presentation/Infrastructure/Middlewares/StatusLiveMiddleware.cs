using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares
{
    public class StatusLiveMiddleware
    {
        public StatusLiveMiddleware(RequestDelegate next)
        {
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Response.HasStarted)
            { 
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync(String.Empty);
            }
           
        }
    }
}