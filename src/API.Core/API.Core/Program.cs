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
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                       Host.CreateDefaultBuilder(args)
                      .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //<--NOTE THIS  ÒÀÀµ×¢Èë
                      .ConfigureWebHostDefaults(webBuilder =>
                      {
                        webBuilder.UseStartup<Startup>();
                      });
    }
}
