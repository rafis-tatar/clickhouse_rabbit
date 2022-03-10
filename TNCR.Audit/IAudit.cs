namespace TNCR.Audit
{
    public interface IAudit
    {
        Task Publish(IProviderMessage message);
    }
}