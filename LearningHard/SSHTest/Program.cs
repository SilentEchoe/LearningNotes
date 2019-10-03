using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;


namespace SSHTest
{
    class Program
    {
        static void Main(string[] args)
        {
          


            string _host = "39.106.221.26";
            string _username = "root";
            string _password = "wk19970424!";
            int _port = 22;
            
            //連線資訊
            ConnectionInfo conInfo = new ConnectionInfo(_host, _port, _username, new AuthenticationMethod[]{
    new PasswordAuthenticationMethod(_username,_password)
});

            //建立SshClient物件
            SshClient sshClient = new SshClient(conInfo);
            Console.WriteLine("輸入 _quite; 則關閉程式");
            //使用無窮迴圈可以一直下Command
            while (true)
            {
                if (!sshClient.IsConnected)
                {
                    //連線
                    sshClient.Connect();
                }

                Console.WriteLine("輸入command:");
                string line = Console.ReadLine();

                //判斷是否關閉程式
                if (line.Equals("_quite;"))
                {
                    break;
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                //執行指令
                SshCommand sshCmd = sshClient.RunCommand(line);
                if (!string.IsNullOrWhiteSpace(sshCmd.Error))
                {
                    Console.WriteLine(sshCmd.Error);
                }
                else
                {
                    Console.WriteLine(sshCmd.Result);
                }
            }
            //關閉連線釋放資源
            sshClient.Disconnect();
            sshClient.Dispose();



        }





    }
}
