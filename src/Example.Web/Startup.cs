using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Harry.Logging;

namespace Example.Web
{
    public class Startup
    {
        ILogger logger = LoggerFactory.Instance.CreateLogger("Example.Web.Startup");
        public Startup(IHostingEnvironment env)
        {
            var filePath =System.IO.Path.Combine( env.ContentRootPath, "NLog.config");
            LoggerFactory.Instance.AddNLog(filePath);
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                logger.Log(LogLevel.Debug, 0, null, $"[{DateTime.Now.ToString()}] test");
                await context.Response.WriteAsync(DateTime.Now.ToString());
            });
        }
    }
}
