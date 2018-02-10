using DL.RabbitMQ.Core.Infrastructure;
using RabbitMQ.Client;

namespace DL.RabbitMQ.Core
{
    public class ChannelProvider : IChannelProvider
    {
        private readonly IRabbitConfigurationProvider _rabbitConfigurationProvider;

        public ChannelProvider(IRabbitConfigurationProvider rabbitConfigurationProvider)
        {
            _rabbitConfigurationProvider = rabbitConfigurationProvider;
        }

        public IModel GetChannel()
        {
            var configuration = _rabbitConfigurationProvider.GetConfiguration();
            
            var factory = new ConnectionFactory
            {
                HostName = configuration.HostName,
                UserName = configuration.UserName,
                Password = configuration.Password
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            connection.AutoClose = true;
            return channel;
        }
    }
}
