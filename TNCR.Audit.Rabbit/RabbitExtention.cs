using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TNCR.Audit.Rabbit
{

    public static class RabbitExtention
    {
        public static IProvider AddRabbitMQProvider(this IAuditBuilder builder, Action<RabbitMQOptions> options=null) 
        {
            //var option = new RabbitMQOptions();
            //options?.Invoke(option);

            //var properties = typeof(RabbitMQOptions).GetProperties();
            //if (properties.Any(p => string.IsNullOrWhiteSpace(p.GetValue(option)?.ToString())))
            //{
            //    var emptyProertys = properties.Where(p => string.IsNullOrWhiteSpace((string)p.GetValue(option)));
            //    throw new ArgumentNullException($"Variables <{string.Join(",", emptyProertys.Select(p => p.Name))}> is not defined");
            //}

            //RabbitMQOptions option = null;
            //if (options != null)
            //{
            //    option = new RabbitMQOptions();
            //    options?.Invoke(option);

            //    var properties = typeof(RabbitMQOptions).GetProperties();
            //    if (properties.Any(p => string.IsNullOrWhiteSpace(p.GetValue(option)?.ToString())))
            //    {
            //        var emptyProertys = properties.Where(p => string.IsNullOrWhiteSpace((string)p.GetValue(option)));
            //        throw new ArgumentNullException($"Variables <{string.Join(",", emptyProertys.Select(p => p.Name))}> is not defined");
            //    }
            //}
            //else //TODO убрать
            //{
            //    option = new RabbitMQOptions()
            //    {
            //        Host = builder.Configuration.GetValueFromEnv<string>("RABBIT_HOST"),
            //        Port = builder.Configuration.GetValueFromEnv<int>("RABBIT_PORT"),
            //        User = builder.Configuration.GetValueFromEnv<string>("RABBIT_USR"),
            //        Pass = builder.Configuration.GetValueFromEnv<string>("RABBIT_PASS"),
            //        Vhost = builder.Configuration.GetValueFromEnv<string>("RABBIT_VHOST"),
            //        Queue = builder.Configuration.GetValueFromEnv<string>("RABBIT_QUEUE"),
            //        Exchange = builder.Configuration.GetValueFromEnv<string>("RABBIT_EXCHANGE"),
            //        RoutingKey = builder.Configuration.GetValueFromEnv<string>("RABBIT_ROUTINGKEY"),
            //    };
            //}

            var provider = builder.AddProvider<RabbitMQProvider, RabbitMQOptions>(options);           
            return provider;
        }
        private static T GetValueFromEnv<T>(this IConfiguration config, string key)
        {
            var value = config[key];
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException($"Variable <{key}> is not defined");
            return (T)Convert.ChangeType(value, typeof(T));
        }      

    }
}