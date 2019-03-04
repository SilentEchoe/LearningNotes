using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ServiceStack.Redis;

namespace LearningRedisApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new RedisManagerPool("localhost:6379");
     
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
