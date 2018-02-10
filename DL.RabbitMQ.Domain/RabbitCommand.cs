using Newtonsoft.Json;

namespace DL.RabbitMQ.Domain
{
    public class RabbitCommand
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public IRabbitCommand Command { get; set; }
    }
}
