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
}
