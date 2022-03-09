using System.Runtime.Serialization;

namespace TNCR.Audit
{
    /// <summary>
    /// Вид события
    /// </summary>
    public enum EventKind
    {
        /// <summary>
        /// Запуск
        /// </summary>
        [EnumMember(Value = "START")]
        START,

        /// <summary>
        /// Завершение 
        /// </summary>
        [EnumMember(Value = "FINISH")]
        FINISH,

        /// <summary>
        /// Событие
        /// </summary>
        [EnumMember(Value = "EVENT")]
        EVENT,

    }
}