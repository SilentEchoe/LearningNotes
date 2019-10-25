using System;
using System.IO;
using System.Text;

namespace WriteTxt
{
    class Program
    {
        static void Main(string[] args)
        {




            for (int i = 0; i < 5; i++)
            {
                WriteTxt("192.168.163.129", "root", "1234");
            }
            

           

        }


        private static void WriteTxt(string ip, string ssh_user, string ssh_pass)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"\host";
            string content = ip + " ansible_ssh_user=" + ssh_user + " ansible_ssh_pass=" + ssh_pass;
            using (FileStream fileStream = File.Open(filePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(content);
                    writer.Close();
                }

                fileStream.Close();
            }
        }

    }
}

