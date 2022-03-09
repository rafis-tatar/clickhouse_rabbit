﻿using System;
using RabbitMQ.Client;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rabbit.Publish;
using TNCR.Audit;

namespace RabbitPublish
{
    class NewTask
    {
        static IConfiguration Configuration;
        static ServiceProvider serviceProvider;
        static JsonSerializerOptions _options;

        public static void Main(string[] args)
        {
            Configure();
            ConfigureJsonOptions();

            Task.Run(RunMethod)
                .ContinueWith((e) => Console.WriteLine("complite!"));

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static void Configure()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            serviceProvider = new ServiceCollection()
                   .AddLogging()
                   .AddSingleton(Configuration)
                   .AddRubbitMQPublisher<RabbitClickhouse>()
                   .BuildServiceProvider();
        }
        private static void ConfigureJsonOptions()
        {
            _options = new JsonSerializerOptions { WriteIndented = true };
            _options.Converters.Add(new JsonStringEnumConverter());
            _options.Converters.Add(new DateTimeJsonConverter());

        }
        private static void RunMethod()
        {
            var audit = new EventAudit()
            {
                Guid = Guid.NewGuid(),

                ApplicationName = "RabbitPublish",
                ModuleName = string.Empty,
                AccountName = "root",
                InstanceName = "DEV",

                EventType = EventType.CONTROLLER,
                EventKind = EventKind.EVENT,
                EventTime = DateTime.UtcNow,
                EventName = "test",
            };
            var rabbitClick = serviceProvider.GetService<RabbitClickhouse>();
            rabbitClick.Publish(audit, _options);           
        }
    }
}