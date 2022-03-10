using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TNCR.Audit
{

    public static class AuditExtensions
    {
        public static IServiceCollection AddAudit(this IServiceCollection services, Action<IAuditBuilder> config = null)
        {
            services.AddScoped(typeof(IAudit), sp => {
                IAuditBuilder builder = new AuditBuilder(sp);
                config?.Invoke(builder);
                var audit = builder.Build();
                return audit;
            });
            
            return services;
        }

        public static IProvider AddProvider<TProvider,TOption>(this IAuditBuilder builder, Action<TOption> options=null) 
            where TProvider : IProvider
            where TOption : IProviderOption
        {
            var option = Activator.CreateInstance<TOption>();
            options?.Invoke(option);
            var publisher  = ActivatorUtilities.CreateInstance<TProvider>(builder.ServiceProvider, option);            
            builder.Add(publisher);
            return publisher;
        }        
    }
}