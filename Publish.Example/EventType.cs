using System.Runtime.Serialization;

namespace RabbitMQ.Client
{
    /// <summary>
    /// Тип события
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "JOB")]
        JOB,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "FORM")]
        FORM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "TABLE")]
        TABLE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "CONTROLLER")]
        CONTROLLER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "LOGIN")]
        LOGIN
    }
}