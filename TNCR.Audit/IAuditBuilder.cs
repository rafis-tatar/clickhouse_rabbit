using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TNCR.Audit
{
    public interface IAuditBuilder
    {
        //IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
        IServiceProvider ServiceProvider { get; }

        void Add(IProvider provider);
        IAudit Build();
    }
}