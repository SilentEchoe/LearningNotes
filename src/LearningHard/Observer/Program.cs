using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            TenXun tenXun = new TenxunGame("TenXun Game", "Have a new game published...");

            // 添加订阅者
            tenXun.AddObserver(new Subscriber("Tim"));
            tenXun.AddObserver(new Subscriber("Tom"));

            tenXun.Update();


            Console.ReadLine();
        }
    }
}
