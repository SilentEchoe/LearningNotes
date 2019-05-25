using System;
using System.Collections.Generic;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace RedisCore
{
    class Program
    {
        static void Main(string[] args)
        {

            var redisHelper = new RedisHelper();
            for (int i = 0; i < 10; i++)
            {
                List<BinFileToCisco> binFile = new List<BinFileToCisco>();
                BinFileToCisco binFileToCiscoile = new BinFileToCisco();
                binFileToCiscoile.Id = 1;
                binFileToCiscoile.Base64 = "1";
                binFileToCiscoile.IsDelete = 0;
                binFileToCiscoile.WriteStatus = 0;
                binFile.Add(binFileToCiscoile);

                redisHelper.ListRightPush("RedisHelperTestonea", binFile);
            }
            var showRedisList = redisHelper.ListRange("RedisHelperTestonea");

            Console.WriteLine();
                   
            Console.ReadLine();

          
        }
    }
}
