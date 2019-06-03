using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            GetLog();

            Console.Read();
        }





        public static void GetLog()
        {
            string filepath = @"C:\FS\FS_Service\Log";
            var files = Directory.GetFiles(filepath, "*.LOG");

            Dictionary<string, string> filebylist = new Dictionary<string, string>();
  
            DateTime todayZeroTime = GetTodayZeroTime(DateTime.Now);
            DateTime tomorrowZeroTime = GetTomorrowZeroTime(DateTime.Now);
            foreach (var file in files)
            {
                
                var fi = new FileInfo(file);

                if (todayZeroTime >= fi.CreationTime && fi.CreationTime >= tomorrowZeroTime)



                    continue;
                Console.WriteLine(file + "," + fi.CreationTime.ToString(CultureInfo.InvariantCulture));

                var a  =  ConvertToBinary(file);
                filebylist.Add(fi.CreationTime.ToString(CultureInfo.InvariantCulture),file);
            }
        }

        /// <summary>
        /// 将文件转换成二进制
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static byte[] ConvertToBinary(string Path)
        {
            FileStream stream = new FileInfo(Path).OpenRead();
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            return buffer;
        }




        private static DateTime GetTodayZeroTime(DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day);
        }

        private static DateTime GetTomorrowZeroTime(DateTime datetime)
        {
            TimeSpan timespan = new TimeSpan(1, 0, 0, 0);
            DateTime yesdt = datetime.Add(timespan);
            return new DateTime(yesdt.Year, yesdt.Month, yesdt.Day);
        }



        // using System.Security.Cryptography;
        public static string GetMd5Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            MD5 md5Hash = MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // 创建一个 Stringbuilder 来收集字节并创建字符串
            StringBuilder sBuilder = new StringBuilder();

            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // 返回十六进制字符串
            return sBuilder.ToString();
        }

    }
}
