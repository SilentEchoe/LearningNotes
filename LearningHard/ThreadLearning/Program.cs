using System;
using System.Threading;
using static System.Threading.Thread;
using static System.Diagnostics.Process;


namespace ThreadLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            // 线程休眠
            //Sleep(200);
            //// 创建线程执行PrintBumBersWithDelay方法
            //Thread thread = new Thread(PrintBumBersWithDelay);

            //Thread thread1 = new Thread(DoNothing);

            //// 启动线程
            //thread.Start();
            //thread1.Start();

            //// 线程状态
            //Console.WriteLine(thread1.ThreadState);

            //// 等待线程
            //thread.Join();

            //// 中止线程thread
            //thread.Abort();




        }


        static void DoNothing()
        {
            // 线程休眠两秒
            Sleep(TimeSpan.FromSeconds(2));
        }


        static void PrintBumBersWithDelay()
        {
            Console.WriteLine("Starting...");

            for (int i = 0; i < 10; i++)
            {
                // 线程休眠
                Sleep(200);
            }

        }


        // 线程优先级
        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadnoe = new Thread(sample.CountNumbers);
            threadnoe.Name = "ThreadNoe";
            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";

            threadnoe.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            threadnoe.Start();
            threadTwo.Start();

        }


    }



    class ThreadSample
    {
        private bool _isStopped = false;

        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumbers()
        {
            long cunter = 0;
            while (!_isStopped)
            {
                cunter++;
            }
            Console.WriteLine($"{CurrentThread.Name } With " + $"{CurrentThread.Priority,11 } Priority" + $"has a count = { cunter,13 }");
        }


    }
}
