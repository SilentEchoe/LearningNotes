using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Genericity
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Compare<int>.compareGeneric(3,4));
            //Console.WriteLine(Compare<string>.compareGeneric("abc","a"));
            //Console.Read();

            TestGeneric();
            TestNonGeneric();
            Console.Read();

        }


        // 测试泛型类型操作的运行时间
        public static void TestGeneric()
        {

            //Stopwatch 对象用来测量运行时间
            Stopwatch stopwatch = new Stopwatch();

            //泛型数组
            List<int> genericlist = new List<int>();

            //开始计时
            stopwatch.Start();

            for (int i = 0; i < 10000000; i++)
            {
                genericlist.Add(i);
            }

            //结束时间
            stopwatch.Stop();

            //输出所用时间
            TimeSpan timeSpan = stopwatch.Elapsed;

            //时间以00：00：00格式输出
            string elapasedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine("泛型时间为："+ elapasedTime);

        }

        // 测试非泛型类型操作的运行时间
        public static void TestNonGeneric()
        {

            //Stopwatch 对象用来测量运行时间
            Stopwatch stopwatch = new Stopwatch();

            //泛型数组
            ArrayList arrayList = new ArrayList();

            //开始计时
            stopwatch.Start();

            for (int i = 0; i < 10000000; i++)
            {
                arrayList.Add(i);
            }

            //结束时间
            stopwatch.Stop();

            //输出所用时间
            TimeSpan timeSpan = stopwatch.Elapsed;

            //时间以00：00：00格式输出
            string elapasedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine("非泛型时间为：" + elapasedTime);

        }




    }
}
