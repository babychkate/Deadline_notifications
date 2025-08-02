using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationService.Services
{
    public class EventListener
    {
        public void Start()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("delayed_exchange", "x-delayed-message", true, false, new Dictionary<string, object>
            {
                { "x-delayed-type", "direct" }
            });

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "delayed_exchange", routingKey: "notify");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[NotificationService] Received message: {message}");
                // Тут можна зробити логіку надсилання сповіщення
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");
            Console.ReadLine();
        }
    }
}
