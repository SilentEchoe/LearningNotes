using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           

            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "admin",//用户名  
                Password = "admin",//密码  
                HostName = "127.0.0.1:15672"//rabbitmq ip
            };

          
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine(" set {0}", message);
                }
            }
        }
    }
}
