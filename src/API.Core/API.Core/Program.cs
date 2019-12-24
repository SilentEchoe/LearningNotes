using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });


        public static IHostBuilder CreateHostBuilder(string[] args) =>
                       Host.CreateDefaultBuilder(args)
                      .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS
                      .ConfigureWebHostDefaults(webBuilder =>
                      {
                        webBuilder.UseStartup<Startup>();
                      });
    }
}
