namespace TNCR.Audit.Rabbit
{
    public class RabbitMQOptions:IProviderOption
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Vhost { get; set; }
        public string Queue { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
    }
}