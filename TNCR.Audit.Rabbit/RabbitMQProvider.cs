using Microsoft.Extensions.Logging;

namespace TNCR.Audit.Rabbit
{
    public class RabbitMQProvider : Provider
    {
        readonly ILogger logger;
        public RabbitMQProvider(RabbitMQOptions option,ILoggerFactory loggerFactory) : base(option)
        {
            logger = loggerFactory.CreateLogger<RabbitMQProvider>();
        }

        public override async Task PublishAsync(IProviderMessage message)
        {
            logger.LogInformation(message.AccountName);
            await Task.Delay(100);
        }
    }
}