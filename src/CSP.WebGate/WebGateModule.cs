using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
//using CSP.Services;

namespace CSP.WebGate
{
//	[DependsOn(typeof(ServiceModule))]
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