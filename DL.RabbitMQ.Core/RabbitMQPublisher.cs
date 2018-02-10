using System.Text;
using DL.RabbitMQ.Core.Infrastructure;
using Newtonsoft.Json;

namespace DL.RabbitMQ.Core
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        private readonly IChannelProvider _channelProvider;

        public RabbitMQPublisher(IChannelProvider channelProvider)
        {
            this._channelProvider = channelProvider;
        }

        public bool Publish<T>(T message, string exchangeType, string exchangeName, string queueName, string routingKey = "default")
        {
            var channel = this._channelProvider.GetChannel();
            channel.ExchangeDeclare(exchangeName, exchangeType, false, false, null);

            channel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(queue: queueName,
                exchange: exchangeName,
                routingKey: routingKey, arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: body,
                mandatory: true);
            channel.Close();
            channel.Dispose();
            return true;
        }
    }
}
