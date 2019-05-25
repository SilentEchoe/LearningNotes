using System;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace MyWindowsService
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(Handle);
        }

        protected override void OnStop()
        {
        }

        //需要定时执行的代码段
        private void Handle()
        {
            while (true)
            {
                try
                {
                    var path = AppDomain.CurrentDomain.BaseDirectory + "service.log";
                    var context = "MyWindowsService: Service Stoped " + DateTime.Now + "\n";
                    WriteLogs(path, context);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void WriteLogs(string path, string context)
        {
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            var sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(context);

            sw.Flush();
            sw.Close();
            fs.Close();
        }


    }
}
