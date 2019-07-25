using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProducerWithFanoutExchange
{
    class Program
    {
        static void Main(string[] args)
        {
			string exchangeName = "TestFanoutChange";
	        string queueName1 = "hello1";
	        string queueName2 = "hello2";
	        string routeKey = "";

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

	        //定义一个Direct类型交换机
	        channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, false, false, null);

	        //定义队列1
	        channel.QueueDeclare(queueName1, false, false, false, null);
	        //定义队列2
	        channel.QueueDeclare(queueName2, false, false, false, null);

			//将队列绑定到交换机
			channel.QueueBind(queueName1, exchangeName, routeKey, null);
			channel.QueueBind(queueName2, exchangeName, routeKey, null);

			//生成两个队列的消费者
	        ConsumerGenerator(queueName1);
	        ConsumerGenerator(queueName2);


			Console.WriteLine($"\nRabbitMQ连接成功，\n\n请输入消息，输入exit退出！");

	        string input;
	        do
	        {
		        input = Console.ReadLine();

		        var sendBytes = Encoding.UTF8.GetBytes(input);
		        //发布消息
		        channel.BasicPublish(exchangeName, routeKey, null, sendBytes);

	        } while (input.Trim().ToLower() != "exit");
	        channel.Close();
	        connection.Close();
		}

		/// <summary>
		/// 根据队列名称生成消费者
		/// </summary>
		/// <param name="queueName"></param>
	    static void ConsumerGenerator(string queueName)
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

			    Console.WriteLine($"Queue:{queueName}收到消息： {message}");
			    //确认该消息已被消费
			    channel.BasicAck(ea.DeliveryTag, false);
		    };
		    //启动消费者 设置为手动应答消息
		    channel.BasicConsume(queueName, false, consumer);
		    Console.WriteLine($"Queue:{queueName}，消费者已启动");
		}

	}
}
