using DL.RabbitMQ.Core;
using DL.RabbitMQ.Core.Infrastructure;

namespace DL.Consumer.Provider
{
    public class RabbitConfigurationProvider : IRabbitConfigurationProvider
    {
        private RabbbitConfiguration _configuration;
        //configuration supposed to come from config file
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
