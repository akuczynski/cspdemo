using CSP.ModuleContracts;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Modularity;
using Volo.Abp;

namespace CSP.MobileWebGate
{
	public class MobileWebGateModule : AbpModule
	{
		//public override void OnApplicationInitialization(ApplicationInitializationContext context)
		//{
		//	var configuraiton = context.ServiceProvider.GetService<IConfiguration>();

		//	var webHostInProcess = configuraiton.GetValue<bool?>("WebHostInProcess");

		//	if (webHostInProcess == null || webHostInProcess == true)
		//	{
		//		var hostService = context.ServiceProvider
		//			.GetRequiredService<IHostService>();

		//		hostService.RunAsync();
		//	}
		//}
	}
}