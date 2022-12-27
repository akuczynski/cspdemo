using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace CSP.Users
{
	 
	public class UsersModule : AbpModule
	{
		public override void OnApplicationInitialization(ApplicationInitializationContext context)
		{
			RegisterRoutePaths(context);
		}

		private void RegisterRoutePaths(ApplicationInitializationContext context)
		{
			var routeService = context.ServiceProvider.GetService<IRouteService>();
			routeService?.AddSerice<UserService>("users");
		}
	}
}