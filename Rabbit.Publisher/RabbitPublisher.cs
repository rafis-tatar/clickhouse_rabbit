using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Publish
{    
    public abstract class RabbitPublisher : IRabbitPublisher, IDisposable
    {
        public ILogger Logger { get; }        
        public  IConnection Connection { get; private set; }
        public ConnectionFactory ConnectionFactory { get; protected set; }
      

        IPublisherOption _option;
        public RabbitPublisher(ILoggerFactory logger, IPublisherOption option)
        {
            Logger = logger.CreateLogger($"{this.GetType().Name}");                       
            _option = option;

            Configure();
        }

        void Configure()
        {
            try
            {
                ConnectionFactory = new ConnectionFactory() { HostName = _option.Host, Port = _option.Port, UserName = _option.User, Password = _option.Pass, VirtualHost = _option.Vhost };
                Connection = ConnectionFactory.CreateConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public virtual void Publish<T>(T message, System.Text.Json.JsonSerializerOptions options =null) where T : new()
        {
            try
            {
                var buff = GetBodyMessage(message, options);
                using (var channel = Connection.CreateModel())
                {
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    channel.BasicPublish(exchange: _option.Exchange, routingKey: _option.RoutingKey, basicProperties: properties, body: buff);
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex.Message);
                throw;
            }
        }

        private static byte[] GetBodyMessage<T>(T message, System.Text.Json.JsonSerializerOptions options)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<object>(message, options);
            var buff = Encoding.UTF8.GetBytes(json);
            return buff;
        }
        public void Dispose()
        {            
            Connection?.Dispose();
            Logger.LogInformation("Disposed");
        }
    }
}
