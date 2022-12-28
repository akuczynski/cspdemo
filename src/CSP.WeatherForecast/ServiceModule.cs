using CSP.ModuleContracts;
using CSP.WebGate;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace CSP.Services
{

    public class ServiceModule : AbpModule
    {
		public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {
            RegisterRoutePaths(context);
		}

		private void RegisterRoutePaths(ApplicationInitializationContext context)
		{
            var routeService = context.ServiceProvider.GetService<IRouteService>();
            routeService?.AddSerice<BookService>("books");
		} 
    }
}