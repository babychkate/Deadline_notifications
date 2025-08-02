using EventService.Models;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Connections;

namespace EventService.Services
{
    public class EventPublisher
    {
        public void PublishEvent(Event ev)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("delayed_exchange", "x-delayed-message", true, false, new Dictionary<string, object>
            {
                { "x-delayed-type", "direct" }
            });

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ev));

            var props = channel.CreateBasicProperties();
            props.Headers = new Dictionary<string, object>
            {
                { "x-delay", 2 * 60 * 1000 } // 2 хв у мілісекундах
            };

            channel.BasicPublish("delayed_exchange", "notify", props, body);
        }
    }
}
