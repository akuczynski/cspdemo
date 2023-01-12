using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.Database;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
using CSP.Books.Services;
using System.Reflection;
using Volo.Abp.VirtualFileSystem;
using GenHTTP.Modules.IO;

namespace CSP.Books
{
    [DependsOn(typeof(DatabaseModule))]
	public class BookModule : AbpModule
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