using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ozon.MerchandiseService.Presentation.Filters;
using Ozon.MerchandiseService.Presentation.Infrastructure.Interceptors;
using Ozon.MerchandiseService.Presentation.StartupFilters;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Extension
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();

                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                
                services.AddControllers(option => option.Filters.Add<GlobalExceptionFilter>());
                
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc(name: "v1", new OpenApiInfo{Title = "Ozon.MerchendiseService.API" , Version = "v1"});
                });
                
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                
            });
            return builder;
        }
    }

    
}