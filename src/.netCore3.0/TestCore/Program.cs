using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bse64 = "AwQHEAAAAAAAAAAGZwAAAB4PAABGUyAgICAgICAgICAgICAgAACQZVNGUC0xMEdTUi04NSAgICBBICAgA1IAeQAaAABCMTkxMjA1MzMzOCAgICAgMTgwNzA1ICBo8AP7NzQwLTAzMTk4MCBSRVYgMDEgICAgICAgICAgICAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            //var binContent = Base64ToBytes(bse64);
            //WriteByteToFile(binContent, "D:/a.bin");
            Console.WriteLine("Test");
            Communication();
            Console.ReadLine();


        }


        static void Communication()
        {
            try
            {
                Console.WriteLine("jianting55555port...");
                string receiverString = null;
                byte[] receiveData = null;
                IPEndPoint remtePoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    UdpClient client = new UdpClient(55555);
                    receiveData = client.Receive(ref remtePoint);
                    receiverString = Encoding.Default.GetString(receiveData);
                    Console.WriteLine("portjieshouinfo:" + receiverString);
                    client.Close();


                    Thread t = new Thread(new ParameterizedThreadStart(Monitor));
                    t.Start(receiverString);
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine("通讯端口异常，请重启服务端");
                Console.WriteLine("===========fengexian===============");
                Console.WriteLine(e);
            }
        }

        static object locker = new object();
        static void Monitor(object obj)
        {
            try
            {

                lock (locker)
                {
                    string port = obj.ToString();
                    Console.WriteLine("jianting" + port + "port...");
                    string receiverString = null;
                    byte[] receiveData = null;
                    IPEndPoint remtePoint = new IPEndPoint(IPAddress.Any, 0);
                    while (true)
                    {
                        UdpClient client = new UdpClient(int.Parse(port));
                        receiveData = client.Receive(ref remtePoint);
                        receiverString = Encoding.Default.GetString(receiveData);
                        string IP = "172.16.7.185";//remtePoint.Address.ToString();
                        client.Close();
                        if (receiverString != null)
                        {
                            //等待一秒钟，让客户端做好接收准备
                            Thread.Sleep(1000);
                            SendUDP(IP, int.Parse(port));
                            return;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("error...");
                Console.WriteLine("===========fengexian===============");
                Console.WriteLine(e);
            }

        }

        static void SendUDP(string Ip, int Port)
        {
            try
            {
                byte[] sendData = null;//要发送的字节数组
                UdpClient client = null;
                sendData = Encoding.Default.GetBytes("OK");

                IPAddress remoteIP = IPAddress.Parse(Ip);
                IPEndPoint remotePoint = new IPEndPoint(remoteIP, Port);
                client = new UdpClient();
                client.Send(sendData, sendData.Length, remotePoint);
                Console.WriteLine("++++++++++++++++++++wancheng");
                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("发送回复失败");
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static byte[] Base64ToBytes(string base64)
        {
            char[] charBuffer = base64.ToCharArray();
            byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);
            return bytes;
        }

        /// <summary>
        /// 写byte[]到fileName
        /// </summary>
        /// <param name="pReadByte">byte[]</param>
        /// <param name="fileName">保存至硬盘路径</param>
        /// <returns></returns>
        public static bool WriteByteToFile(byte[] pReadByte, string fileName)
        {
            FileStream pFileStream = null;
            try
            {
                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                pFileStream.Write(pReadByte, 0, pReadByte.Length);
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return false;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
            return true;
        }



    }
}
