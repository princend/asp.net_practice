using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
            services.AddTransient<ISampleTransient, Sample>();
            services.AddScoped<ISample, Sample>();
            services.AddSingleton<ISampleSingleton, Sample>();

            // Program.Output("startup.configureservice -called");

            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var defaultRouteHandler = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync($"Route values:{string.Join(",", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, defaultRouteHandler);

            routeBuilder.MapRoute("default", "{first:regex(^(default|home)$)}/{second?}");

            routeBuilder.MapGet("user/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Get user.name: {name}");
            });

            routeBuilder.MapPost("user/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"create user.name {name}");
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseFirstMiddleware();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!\r\n");
                });
            });

            app.Map("/second", mapApp =>
            {
                mapApp.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("in\r\n");
                    await next.Invoke();
                    await context.Response.WriteAsync("out\r\n");
                });
                mapApp.Run(async context =>
                {
                    await context.Response.WriteAsync("second \r\n");
                });
            });
        }
    }
}
