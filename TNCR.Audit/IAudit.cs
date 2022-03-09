using System;

namespace TNCR.Audit
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAudit
    {
        /// <summary>
        /// Идентификатор события
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Наименование приложения инициировавшего событие
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// Наименование модуля инициировавшего событие
        /// </summary>
        string ModuleName { get; set; }

        /// <summary>
        /// Имя аккаунта от чео имени вызвано событие
        /// </summary>
        string AccountName { get; set; }

        /// <summary>
        /// Наименование ланшафта
        /// </summary>
        string InstanceName { get; set; }
    }
}