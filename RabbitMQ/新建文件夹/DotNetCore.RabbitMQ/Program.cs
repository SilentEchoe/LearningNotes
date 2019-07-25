using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
			//创建连接工厂
	        ConnectionFactory factory = new ConnectionFactory
	        {
		        UserName = "admin",//用户名
		        Password = "admin",//密码
		        HostName = "192.168.157.130"//rabbitmq ip
	        };

			//创建连接
	        var connection = factory.CreateConnection();
			//创建通道
	        var channel = connection.CreateModel();
			//声明一个队列
	        channel.QueueDeclare("hello", false, false, false, null);

			Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

	        string input;
	        do
	        {
		        input = Console.ReadLine();

		        var sendBytes = Encoding.UTF8.GetBytes(input);
				//发布消息
				channel.BasicPublish("", "hello", null, sendBytes);

			} while (input.Trim().ToLower()!="exit");
	        channel.Close();
	        connection.Close();

		}
    }
}
