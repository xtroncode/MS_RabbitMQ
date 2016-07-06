using RabbitMQ.Client;
using System;
using System.Text;

namespace MS_RabbitMQ
{
    public class A
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("tweets", false, false, false, null);

                    string message = "Hi Rabbit";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "hello", null, body);

                    Console.WriteLine("{0} sent", message);
                }
            }
        }

    }
}
