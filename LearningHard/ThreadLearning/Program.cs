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


            //for (int i = 0; i <= 6; i++)
            //{
            //    string threadName = "Thread" + i;
            //    int sencondstowait = 2 + 2 * i;
            //    var t = new Thread(() => SemaphoreSlimTest(threadName, sencondstowait));
            //    t.Start();
            //}


        }

        // 线程同步
        // 使用Mutex类
        private void MutexTest()
        {
            const string MutexName = "CSharpThreadingCookBook";

            using (var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("Second instance is running");
                }
                else
                {
                    Console.WriteLine("Running");
                    Console.ReadLine();
                    m.ReleaseMutex();
                }


            }
        }

        // 使用SemaphoreSlim 限制同一资源的线程数量(4)
        // 限定并发
        static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(4);

        private static void SemaphoreSlimTest(string name , int seconds)
        {
            Console.WriteLine($"{name} waits to access a database");
            _semaphoreSlim.Wait();
            Console.WriteLine($"{name} was granted an access to a database");
            Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name} is completed");
            _semaphoreSlim.Release();
        }

        //AutoResetEvent 线程通知


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
            var threadnoe = new Thread(sample.CountNumbers)
            {
                Name = "ThreadNoe"
            };

            threadnoe.Priority = ThreadPriority.Highest;
            new Thread(sample.CountNumbers)
            {
                Name = "ThreadTwo"
            }.Priority = ThreadPriority.Lowest;
            threadnoe.Start();
            new Thread(sample.CountNumbers)
            {
                Name = "ThreadTwo"
            }.Start();

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
