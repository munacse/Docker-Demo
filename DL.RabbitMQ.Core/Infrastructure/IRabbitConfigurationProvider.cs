using DL.RabbitMQ.Domain;

namespace DL.RabbitMQ.Core.Infrastructure
{
    public interface IRabbitConfigurationProvider
    {
        RabbbitConfiguration GetConfiguration();
    }
}