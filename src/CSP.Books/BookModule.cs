using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
using CSP.Books.Services;
using Volo.Abp.AutoMapper;
using Volo.Abp.Account;

namespace CSP.Books
{
    [DependsOn(
		typeof(CSPApplicationModule)
//		typeof(CSPDomainModule),
//		typeof(AbpAccountApplicationModule),
//		typeof(CSPApplicationContractsModule)
		)]
	public class BookModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			//Configure<AbpAutoMapperOptions>(options =>
			//{
			//	options.AddMaps<BookModule>();
			//});
		}
	}
}