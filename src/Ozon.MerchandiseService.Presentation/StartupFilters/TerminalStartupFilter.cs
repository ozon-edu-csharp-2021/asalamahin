using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares;

namespace Ozon.MerchandiseService.Presentation.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/ready", app => app.UseMiddleware<StatusReadyMiddleware>());
                app.Map("/version" ,app => app.UseMiddleware<VersionMiddleware>());
                app.Map("/live", app => app.UseMiddleware<StatusLiveMiddleware>());
                app.UseMiddleware<LoggingMiddleware>();
                
                next(app);
            };
        }
    }
}