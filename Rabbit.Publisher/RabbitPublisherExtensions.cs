using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Rabbit.Publish
{
    public static class RabbitPublisherExtensions
    {        
        public static IServiceCollection AddRubbitMQPublisher<T>(this IServiceCollection services, Action<IPublisherOption> action=null) where T : RabbitPublisher
        {
            services.AddScoped(typeof(T), sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                var configuration = sp.GetRequiredService<IConfiguration>();

                IPublisherOption option = GetOption(configuration, action);
                var publisher = ActivatorUtilities.CreateInstance<T>(sp, loggerFactory, option);
                return publisher;
            });
            return services;
        }
        private static T GetValueFromEnv<T>(this IConfiguration config, string key)
        {
            var value = config[key];
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException($"Variable <{key}> is not defined");
            return (T)Convert.ChangeType(value, typeof(T));
        }
        private static IPublisherOption GetOption(IConfiguration configuration, Action<IPublisherOption> action)
        {
            IPublisherOption option = null;
            if (action != null)
            {
                option = new PublisherOption();
                action(option);

                var properties = typeof(PublisherOption).GetProperties();
                if (properties.Any(p => string.IsNullOrWhiteSpace(p.GetValue(option)?.ToString())))
                {
                    var emptyProertys = properties.Where(p => string.IsNullOrWhiteSpace((string)p.GetValue(option)));
                    throw new ArgumentNullException($"Variables <{string.Join(",", emptyProertys.Select(p => p.Name))}> is not defined");
                }
            }
            else
            {
                option = new PublisherOption()
                {
                    Host = configuration.GetValueFromEnv<string>("RABBIT_HOST"),
                    Port = configuration.GetValueFromEnv<int>("RABBIT_PORT"),
                    User = configuration.GetValueFromEnv<string>("RABBIT_USR"),
                    Pass = configuration.GetValueFromEnv<string>("RABBIT_PASS"),
                    Vhost = configuration.GetValueFromEnv<string>("RABBIT_VHOST"),
                    Queue = configuration.GetValueFromEnv<string>("RABBIT_QUEUE"),
                    Exchange = configuration.GetValueFromEnv<string>("RABBIT_EXCHANGE"),
                    RoutingKey = configuration.GetValueFromEnv<string>("RABBIT_ROUTINGKEY"),
                };
            }
            return option;
        }
    }
}
