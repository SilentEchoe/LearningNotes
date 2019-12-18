using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SignalRTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

           var host = CreateHostBuilder(args).Build();


           host.Run();
            //BuildWebHost(args).Run();
            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseUrls("http://localhost:56789")
              .UseStartup<Startup>()
              .Build();


        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
         .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder
             .ConfigureKestrel(serverOptions =>
             {
                 serverOptions.AllowSynchronousIO = true;//∆Ù”√Õ¨≤Ω IO
                })
             .UseStartup<Startup>()
             .UseUrls("http://localhost:8081")
             .ConfigureLogging((hostingContext, builder) =>
             {
                 builder.ClearProviders();
                 builder.SetMinimumLevel(LogLevel.Trace);
                 builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 builder.AddConsole();
                 builder.AddDebug();
             });
         });


    }
}
