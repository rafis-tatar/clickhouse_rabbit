using RabbitMQ.Client;

namespace Rabbit.Publish
{
    public interface IRabbitPublisher
    {
        /// <summary>
        /// 
        /// </summary>
        ConnectionFactory ConnectionFactory { get; }

        /// <summary>
        /// 
        /// </summary>
        IConnection Connection { get;}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="options"></param>
        void Publish<T>(T message, System.Text.Json.JsonSerializerOptions options) where T : new();
    }


    //public sealed class Publisher: RabbitPublisherBase
    //{
    //    ILogger _logger;        
    //    IConfiguration _configuration;
    //    PublisherOption _option;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="logger"></param>
    //    public Publisher(ILoggerFactory logger, IConfiguration configuration, PublisherOption option) :base(logger)
    //    {            
    //        _configuration = configuration;
    //        _option= option;
    //        Configure();
    //    }       

    //    void Configure()
    //    {           

    //        try
    //        {
    //            ConnectionFactory = new ConnectionFactory() { HostName = _option.Host, Port = _option.port, UserName = _option.user, Password = _option.pass, VirtualHost =_option.vhost };
    //            Connection = ConnectionFactory.CreateConnection();
    //            Channel = Connection.CreateModel();
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex.Message);
    //            throw;
    //        }           
    //    }

    //    public override void Publish<T>(T message)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private static byte[] GetBodyMessage<T>(T message, System.Text.Json.JsonSerializerOptions options)
    //    {
    //        var json = System.Text.Json.JsonSerializer.Serialize<object>(message, options);
    //        var buff = Encoding.UTF8.GetBytes(json);
    //        return buff;
    //    }

        /*
                    try
                    {


                        using (var channel = connection.CreateModel())
                        {
                            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                            var properties = channel.CreateBasicProperties();
                            properties.Persistent = true;



                            int t = 0;
                            while (true)
                            {
                                t++;
                                if (t > 15) break;
                                var audit = new AuditEvent()
                                {
                                    EventType = EventType.CONTROLLER,
                                    EventTime = DateTime.UtcNow,
                                    EventName = "test",
                                    InstanceName = "DEV",
                                    ApplicationName = "RabbitPublish",
                                    AccountName = "root",
                                    Value = $"t={t}",
                                    Guid = Guid.Empty,
                                    ModuleName = String.Empty
                                };

                                var body = GetBodyMessage(audit);
                                channel.BasicPublish(exchange: "exchange", routingKey: "audit_log", basicProperties: properties, body: body);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
        */


    //}


}
