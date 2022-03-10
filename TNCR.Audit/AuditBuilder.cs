using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace TNCR.Audit
{
    class AuditBuilder : IAuditBuilder
    {
        //public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; }    

        public AuditBuilder(/*IServiceCollection services,*/IServiceProvider serviceProvider)
        {
            //Services = services;
            ServiceProvider = serviceProvider;
            Configuration = serviceProvider.GetRequiredService<IConfiguration>();
        }

        List<IProvider> _providers = new List<IProvider>();        
        public void Add(IProvider provider) => _providers.Add(provider);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IAudit Build() => Audit.Create(_providers);
    }

    class Audit : IAudit
    {
        public static Audit Create(IList<IProvider> providers) => new Audit(providers);

        public readonly IReadOnlyCollection<IProvider> Providers;
        protected Audit(IList<IProvider> providers)
        {
            Providers = new ReadOnlyCollection<IProvider>(providers);
        }       

        public async Task Publish(IProviderMessage message)
        {            
            foreach(var provider in Providers)
            {
                await provider.PublishAsync(message);
            }            
        }
    }
}