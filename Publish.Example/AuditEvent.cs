using System;
using System.Text.Json.Serialization;

namespace RabbitMQ.Client
{
    /// <summary>
    /// 
    /// </summary>
    public record AuditEvent : IAuditEvent
    {
        /// <summary>
        /// Тип события
        /// </summary>          
        public EventType EventType { get; set; }
        /// <summary>
        /// Имя события
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// Время события
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// Наименование приложения инициировавшего событие
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Имя модуля
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// Тип экземпляра (DEV|PROD|STAGE и т.д.)
        /// </summary>
        public string InstanceName { get; set; } 
        /// <summary>
        /// Имя аккаунта от чео имени вызвано событие
        /// </summary>
        public string AccountName { get; set; }
        ///// <summary>
        ///// GUID для группировок связанных событий, не обязательный параметр.
        ///// </summary>
        public Guid Guid { get; set; }
        ///// <summary>
        /// Произвольное значение в строковом пердставлении 
        /// </summary>
        public string Value { get; set; }

    }
}