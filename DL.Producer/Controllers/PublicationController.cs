using DL.RabbitMQ.Core.Infrastructure;
using DL.RabbitMQ.Domain.Command;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace DL.Producer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublicationController : Controller
    {
        private readonly IRabbitMQPublisher _rabbitMqPublisher;

        public PublicationController(IRabbitMQPublisher rabbitMqPublisher)
        {
            this._rabbitMqPublisher = rabbitMqPublisher;
        }

        [HttpPost]
        public void Post([FromBody]Student student)
        {
          this._rabbitMqPublisher.Publish(student, ExchangeType.Direct, "docker.test.exchange", "docker.test.queue");
        }
  }
}