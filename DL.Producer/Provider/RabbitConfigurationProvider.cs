using DL.RabbitMQ.Core;
using DL.RabbitMQ.Core.Infrastructure;

namespace DL.Producer.Provider
{
    public class RabbitConfigurationProvider : IRabbitConfigurationProvider
    {
        private RabbbitConfiguration _configuration;

        public RabbbitConfiguration GetConfiguration()
        {
            return this._configuration ?? (this._configuration = new RabbbitConfiguration
            {
                HostName = "rabbitMQ",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            });
        }
    }
}
