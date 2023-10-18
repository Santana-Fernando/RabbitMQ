using RabbitMQ.Client;
using System;
using System.Text;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "saldacao_1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = "Bem-vindo ao RabbitMQ";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "saldacao_1",
                    basicProperties: null,
                    body: body);

                Console.WriteLine($"[X] Enviada: {message}");
            }
            Console.ReadLine();
        }
    }
}
