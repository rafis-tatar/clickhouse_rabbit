namespace Rabbit.Publish
{
    public interface IPublisherOption
    {
        /// <summary>
        /// Хост
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        int Port { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        string User { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        string Pass { get; set; }
        
        /// <summary>
        /// Виртуальный каталог
        /// </summary>
        string Vhost { get; set; }

        /// <summary>
        /// Иимя очереди
        /// </summary>
        string Queue { get; set; }

        /// <summary>
        /// Имя точки обмена
        /// </summary>
        string Exchange { get; set; }

        /// <summary>
        /// ключ маршрута
        /// </summary>
        string RoutingKey { get; set; }
    }
}
