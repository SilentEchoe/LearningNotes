using System;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Test2
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Process.Start(@"C:\Users\Lenovo\Desktop\ceshi\FS_Feedback\FS_Feedback.exe");




            //Process[] app = Process.GetProcessesByName("FS_Feedback");
            //if (app.Length > 0)
            //{
            //    Console.WriteLine("已启动");   
            //    return;
            //}

            DirectoryInfo info = new DirectoryInfo(@"C:\FS\FS_Service\Log\");

            DateTime a =  DateTime.Today;
            DateTime b =  a.AddDays(1);
            var allLines = info.GetFiles("*.LOG")
                .Where(p => p.CreationTime.Date > a && p.CreationTime.Date < b);


          
            Console.WriteLine("Hello World!");
        }
    }
}
