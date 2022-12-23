using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;

namespace CSP.WebGate
{
    public class WebGateModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var hostService = context.ServiceProvider
                .GetRequiredService<IHostService>();

            hostService.Run();
		}
    }
}