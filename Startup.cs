using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace myweb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Program.Output("startup.configureservice -called");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Hosting.IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {

                applicationLifetime.ApplicationStarted.Register(() =>
                {
                    // Program.Output("lifetime started");
                });

                applicationLifetime.ApplicationStopping.Register(() =>
                {
                    // Program.Output("lifetime stopping");
                });

                applicationLifetime.ApplicationStopped.Register(() =>
                {
                    // Thread.Sleep(5 * 1000);
                    Program.Output("lifetime stopped");
                });

                Program.Output("configure isdevelopment");
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("first middleawre in \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("first middleware out \r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("second middleawre in \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("second middleware out \r\n");
            });


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // Program.Output("get");
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            // var thread = new Thread(new ThreadStart(() =>
            // {
            //     Thread.Sleep(5 * 1000);
            //     Program.Output("triger stop webhost");
            //     applicationLifetime.StopApplication();
            // }));
            // thread.Start();
        }
    }
}
