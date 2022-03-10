namespace TNCR.Audit
{
    public abstract class Provider : IProvider
    {
        public IProviderOption Option { get; }
        protected Provider(IProviderOption option)
        {
            Option = option;
        }
        public abstract Task PublishAsync(IProviderMessage message);
    }
}