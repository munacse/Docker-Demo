using RabbitMQ.Client;

namespace DL.RabbitMQ.Core.Infrastructure
{
    public interface IChannelProvider
    {
        IModel GetChannel();
    }
}