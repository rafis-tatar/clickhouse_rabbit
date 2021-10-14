using System;
using RabbitMQ.Client;
using System.Text;

class NewTask
{
public static void Main(string[] args)
    {
        int t= 0;
            Task.Run(()=>
                {
                    var factory = new ConnectionFactory() { HostName = "localhost", Port=5672, UserName="clickhouse", Password="clickhouse" };
                    using(var connection = factory.CreateConnection())
                    using(var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "cars",
                                            durable: true,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);          

                        var properties = channel.CreateBasicProperties();
                        properties.Persistent = true;

                       
                        while(true)
                        {
                            t++;
                            if (t > 100000) break;
                            var message = GetMessage();
                            var body = Encoding.UTF8.GetBytes(message);
                            channel.BasicPublish(exchange: "exchange",
                                                routingKey: "cars",
                                                basicProperties: properties,
                                                body: body);                
                            //Task.Delay(10);            
                        }
                    }
                }
            ).ContinueWith(delegate{
                Console.WriteLine("complite : "+t);
            });
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
    }

static int id=0;
    private static string GetMessage()
    {

        return "{\n\"device_id\": \"test"+(id++)+"\",\n\"datetime\": \""+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\",\n\"latitude\": 55.70329032,\n\"longitude\": 37.65472196,\n\"altitude\": 427.5,\n\"speed\": 0,\n\"battery_voltage\": 23.5,\n\"cabin_temperature\": 17,\n\"fuel_level\": null\n}\n{\n\"device_id\": \"test"+(id++)+"\",\n\"datetime\": \""+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\",\n\"latitude\": 55.71294467,\n\"longitude\": 37.66542005,\n\"altitude\": 429.13,\n\"speed\": 55.5,\n\"battery_voltage\": null,\n\"cabin_temperature\": 18,\n\"fuel_level\": 32\n}\n{\n\"device_id\": \"test"+(id++)+"\",\n\"datetime\": \""+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\",\n\"latitude\": 55.70985913,\n\"longitude\": 37.62141918,\n\"altitude\": 417.0,\n\"speed\": 15.7,\n\"battery_voltage\": 10.3,\n\"cabin_temperature\": 17,\n\"fuel_level\": null\n}";
     
    }
}
