using Volo.Abp.Modularity; 
using Volo.Abp.Auditing;
using Volo.Abp.AspNetCore.Mvc;

namespace CSP.Books
{
    [DependsOn(typeof(CSPApplicationModule))]
	public class BookModule : AbpModule
	{ 
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpAuditingOptions>(options =>
			{
				options.IsEnabled = false; //Disables the auditing system
			});

			ConfigureAutoApiControllers();
		}

		private void ConfigureAutoApiControllers()
		{
			Configure<AbpAspNetCoreMvcOptions>(options =>
			{
				options.ConventionalControllers.Create(typeof(BookModule).Assembly);
			});
		}
	}
}