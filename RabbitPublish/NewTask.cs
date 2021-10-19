using System;
using RabbitMQ.Client;
using System.Text;
using System.Globalization;

class NewTask
{
public static void Main(string[] args)
    {
        int t= 0;
            Task.Run(()=>
                {
					try{
                    var factory = new ConnectionFactory() { HostName = "localhost", Port=5672, UserName="clickhouse", Password="clickhouse", VirtualHost="audit" };
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
                            var   message = GetMessage(50000); 
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
    static Random r= new ();
    private static string GetMessage(int lengt = 500)
    {

        StringBuilder stringBuilder=new();        
        for (int i = 0; i < lengt; i++)
        {
            var lat = (55.0 + Math.Round(r.NextDouble(),8)).ToString(CultureInfo.InvariantCulture);
            var lon = (52.0 + Math.Round(r.NextDouble(),8)).ToString(CultureInfo.InvariantCulture);        
            stringBuilder.Append("{\n");
            stringBuilder.Append($"\"device_id\": \"test{id++}\",\n\"datetime\": \"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\",\n\"latitude\": {lat},\n\"longitude\": {lon},\n\"altitude\": 427.5,\n\"speed\": 0,\n\"battery_voltage\": 23.5,\n\"cabin_temperature\": 17,\n\"fuel_level\": null");
            stringBuilder.Append("\n}\n");
        }        
        return stringBuilder.ToString();
    }
}
