using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
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

			//事件基本消费者
			EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

			//接收到消息事件
	        consumer.Received += (ch, ea) =>
	        {
		        var message = Encoding.UTF8.GetString(ea.Body);

		        Console.WriteLine($"收到消息： {message}");

//				Console.WriteLine($"收到该消息[{ea.DeliveryTag}] 延迟10s发送回执");
//				Thread.Sleep(10000);
				//确认该消息已被消费
		        channel.BasicAck(ea.DeliveryTag, false);
//		        Console.WriteLine($"已发送回执[{ea.DeliveryTag}]");
			};
			//启动消费者 设置为手动应答消息
			channel.BasicConsume("hello", false, consumer);
	        Console.WriteLine("消费者已启动");
	        Console.ReadKey();
	        channel.Dispose();
	        connection.Close();

		}
    }
}
