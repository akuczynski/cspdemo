//using CSP.Database;
using CSP.Database;
using CSP.ModuleContracts;
using CSP.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
//using Volo.Abp.Dapper;
using Volo.Abp.Modularity;

namespace CSP.Users
{
	[DependsOn(typeof(DatabaseModule))]
	public class UsersModule : AbpModule
	{
		public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
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