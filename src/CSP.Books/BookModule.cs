using Volo.Abp.Modularity;  
namespace CSP.Books
{
    [DependsOn(typeof(CSPApplicationModule))]
	public class BookModule : AbpModule
	{ 
		public override void ConfigureServices(ServiceConfigurationContext context)
		{			 
		} 
	}
}