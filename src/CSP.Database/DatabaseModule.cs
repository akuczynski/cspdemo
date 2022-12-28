//using Abp.Dependency;
using CSP.ModuleContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Dapper;
using Volo.Abp.Modularity;

namespace CSP.Database
{
	[DependsOn(typeof(AbpDapperModule))]
	public class DatabaseModule :  AbpModule
	{
		public override void OnApplicationInitialization(ApplicationInitializationContext context)
		{
			var appSettings = context.ServiceProvider.GetService<IApplicationSettings>();
			DbSettings.DatabasePath = appSettings!.DatabasePath;
		}
	}
}