using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            int x = 10;
            int y = 15;
            double z = 0;

            app.Use(async (contex, next) =>
            {
                z = (Math.Acos(x) + Math.Sin(y)) / Math.Log10(x * y);
                await next.Invoke();
            });
            
            app.Run(async (context) => { await context.Response.WriteAsync($"(Cos(x) + Sin(x))/ ln(x * y) = {z}"); });
        }
    }
}