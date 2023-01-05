//using CSP.Books;
using CSP.Core;
using CSP.Data;
using CSP.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CSP.MainApp;

[DependsOn(typeof(AbpAutofacModule),
		   typeof(CSPEntityFrameworkCoreModule),	
	 	   typeof(CSPApplicationModule)
	)]
public class MainAppModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext context)
	{
	
		Configure<AbpAuditingOptions>(options =>
		{
			options.IsEnabled = false; //Disables the auditing system
		});
	}

	public override async void OnApplicationInitialization(ApplicationInitializationContext context)
	{
		base.OnApplicationInitialization(context);

	 	await ApplyMigrations(context);
	} 

	private async Task ApplyMigrations(ApplicationInitializationContext context)
	{
		var appSettings = context.ServiceProvider.GetRequiredService<IApplicationSettings>();

		var migrationService = context.ServiceProvider.GetService<CSPDbMigrationService>();
		await migrationService.MigrateAsync();
	} 
}
