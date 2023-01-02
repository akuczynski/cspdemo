using CSP.Books;
using CSP.MobileWebGate;
using CSP.Users;
using CSP.WebGate;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CSP.MainApp;

[DependsOn(typeof(AbpAutofacModule), 
		   typeof(WebGateModule),
		   typeof(MobileWebGateModule),
		   typeof(UsersModule), 
		   typeof(BookModule)
	)]
public class MainAppModule : AbpModule
{
}
