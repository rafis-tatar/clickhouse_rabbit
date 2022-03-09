using System.Runtime.Serialization;

namespace TNCR.Audit
{


    /// <summary>
    /// Тип события
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Событие формы
        /// </summary>
        [EnumMember(Value = "FORM")]
        FORM,

        /// <summary>
        /// Событие задания
        /// </summary>
        [EnumMember(Value = "JOB")]
        JOB,

        /// <summary>
        /// Событие контроллера
        /// </summary>
        [EnumMember(Value = "CONTROLLER")]
        CONTROLLER,

        /// <summary>
        /// Событие аутентификации
        /// </summary>
        [EnumMember(Value = "AUTH")]
        AUTH
    }
}