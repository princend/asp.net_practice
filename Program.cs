using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace myweb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Output("start");
            CreateHostBuilder(args).Build().Run();
            // Output("end");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Output("before");
                    webBuilder.UseStartup<Startup>();
                    // Output("build Webhost");
                });


        public static void Output(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}]{message}");
        }
    }
}
