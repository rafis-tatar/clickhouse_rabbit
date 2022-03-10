namespace TNCR.Audit
{

    /// <summary>
    /// 
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        /// <typeparam name="T">Тип сообщения</typeparam>
        /// <param name="message">Сообщение</param>
        Task PublishAsync(IProviderMessage message);
    }
}