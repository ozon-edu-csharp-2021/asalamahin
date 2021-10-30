using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var vers = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown version";
            var resp = new { version = vers, serviceName = Assembly.GetExecutingAssembly().GetName().Name};
            
            await context.Response.WriteAsync(JsonConvert.SerializeObject(resp));
        }
    }
}