using DL.RabbitMQ.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DL.RabbitMQ.Core
{
    public class RabbitDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<IChannelProvider, ChannelProvider>();
            services.AddSingleton<IRabbitMQReceiver, RabbitMQReceiver>();
            services.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();
        }
    }
}
