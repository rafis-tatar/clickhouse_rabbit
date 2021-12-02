using System;

namespace RabbitMQ.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuditEvent
    {
        /// <summary>
        /// Тип события
        /// </summary>
        EventType EventType { get; set; }
        /// <summary>
        /// Имя события
        /// </summary>
        string EventName { get; set; }
        /// <summary>
        /// Время события
        /// </summary>
       // DateTime EventTime { get; set; }
        /// <summary>
        /// Наименование приложения инициировавшего событие
        /// </summary>
        string ApplicationName { get; set; }
        /// <summary>
        /// Имя аккаунта от чео имени вызвано событие
        /// </summary>
        string AccountName { get; set; }
    }
}