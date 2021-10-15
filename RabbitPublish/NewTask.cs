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
					try{
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
                            if (t > 10) break;
                            var message = GetMessage();
                            var body = Encoding.UTF8.GetBytes(message);
                            channel.BasicPublish(exchange: "exchange",
                                                routingKey: "cars",
                                                basicProperties: properties,
                                                body: body);                                            
                        }
                    }
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
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

        return "{\n\"device_id\": \"test"+(id++)+"\",\n\"datetime\": \""+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\",\n\"latitude\": 55.70329032,\n\"longitude\": 37.65472196,\n\"altitude\": 427.5,\n\"speed\": 0,\n\"battery_voltage\": 23.5,\n\"cabin_temperature\": 17,\n\"fuel_level\": null\n}\n";
     
    }
}
