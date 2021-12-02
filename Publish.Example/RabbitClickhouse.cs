using Microsoft.Extensions.Logging;
using Rabbit.Publish;

namespace RabbitPublish
{
    public class RabbitClickhouse : RabbitPublisher
    {
        public RabbitClickhouse(ILoggerFactory logger, IPublisherOption option) : base(logger, option) { }
    }   
}
