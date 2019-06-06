using System;
using StackExchange.Redis;

namespace RedisCore
{
    class Program
    {
        static void Main(string[] args)
        {

            //var redisHelper = new RedisHelper();
            //for (int i = 0; i < 10; i++)
            //{
            //    List<BinFileToCisco> binFile = new List<BinFileToCisco>();
            //    BinFileToCisco binFileToCiscoile = new BinFileToCisco();
            //    binFileToCiscoile.Id = 1;
            //    binFileToCiscoile.Base64 = "1";
            //    binFileToCiscoile.IsDelete = 0;
            //    binFileToCiscoile.WriteStatus = 0;
            //    binFile.Add(binFileToCiscoile);

            //    redisHelper.ListRightPush("RedisHelperTestonea", binFile);
            //}
            //var showRedisList = redisHelper.ListRange("RedisHelperTestonea");

            RedisConnection.Init("127.0.0.1:6379");
            var redis = RedisConnection.Instance.ConnectionMultiplexer;
            redis.GetDatabase(0);
            var sub = redis.GetSubscriber();
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} - Subscribed channel topic.test ");
            sub.Subscribe("topic.test", (channel, message) =>
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} - Received message {message}");
            });

            redis.GetDatabase().Publish("topic.test", "Hello World!");
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} - Published message to channel topic.test");

            for (int i = 0; i < 10; i++)
            {
                redis.GetDatabase().PublishAsync("topic.test", $"{i} Hello World!");
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} - Published message to channel topic.test");
            }


            Console.ReadLine();

          
        }
    }
}
