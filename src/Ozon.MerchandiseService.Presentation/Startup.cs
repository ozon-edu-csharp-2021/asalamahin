using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ozon.MerchandiseService.Presentation.GrpcServices;
using Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares;

namespace Ozon.MerchandiseService.Presentation
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchandiseServiceGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}