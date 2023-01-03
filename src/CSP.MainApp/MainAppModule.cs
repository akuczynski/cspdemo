using CSP.Books;
using CSP.MobileWebGate;
using CSP.Users;
using CSP.WebGate;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CSP.MainApp;

[DependsOn(typeof(AbpAutofacModule),
		   typeof(WebGateModule),
		  // typeof(AspWebGateModule),
		   typeof(MobileWebGateModule),
		   typeof(UsersModule), 
		   typeof(BookModule)
	)]
public class MainAppModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext context)
	{
		//Configure<AbpAutoMapperOptions>(options =>
		//{
		//	options.AddMaps<BookModule>();
		//});
		Configure<AbpAuditingOptions>(options =>
		{
			options.IsEnabled = false; //Disables the auditing system
		});
	}
}
