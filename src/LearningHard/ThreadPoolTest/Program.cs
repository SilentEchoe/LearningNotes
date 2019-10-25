using System;

using System.Threading;
using static System.Threading.Thread;

namespace ThreadPoolTest
{
    class Program
    {

        private delegate string RunOnThreadPool(out int threadId);
        static void Main(string[] args)
        {
            int threadId = 0;

            RunOnThreadPool poolDelegate = Test;

            var t = new Thread(() => Test(out threadId));

            t.Start();
            t.Join();

            Console.WriteLine($"Thread id :{threadId}");

            IAsyncResult r = poolDelegate.BeginInvoke(out threadId, Callback, "内容");

            string result = poolDelegate.EndInvoke(out threadId, r);

            Console.WriteLine($"Thread pool worker thread id:{threadId}");

            Console.WriteLine(result);

            Sleep(TimeSpan.FromSeconds(2));

        }

        private static void Callback(IAsyncResult asyncResult)
        {
            Console.WriteLine("Starting a callback....");

            Console.WriteLine($"State passed to a Callbak:{asyncResult.AsyncState}");

            Console.WriteLine($"Is thread pool thread:{CurrentThread.IsThreadPoolThread}");

            Console.WriteLine($"Thread pool worker thread id:{CurrentThread.ManagedThreadId}");
        }


        private static string Test(out int threadId)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine($"Is thread pool thread:{CurrentThread.IsThreadPoolThread}");
            Sleep(TimeSpan.FromSeconds(2));
            threadId = CurrentThread.ManagedThreadId;
            return $"Thread pool worker thread id was: {threadId}";
        }




    }
}
