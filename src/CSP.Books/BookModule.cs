using Volo.Abp.Modularity;
using Volo.Abp;
using CSP.ModuleContracts;
using Microsoft.Extensions.DependencyInjection;
using CSP.Books.Services;
using Volo.Abp.AutoMapper;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Auditing;

namespace CSP.Books
{
    [DependsOn(
		typeof(CSPApplicationModule),
		typeof(CSPDomainModule),
		typeof(AbpAccountApplicationModule),
		typeof(CSPApplicationContractsModule),
		typeof(AbpIdentityApplicationModule),
		typeof(AbpPermissionManagementApplicationModule),
		typeof(AbpTenantManagementApplicationModule),
		typeof(AbpFeatureManagementApplicationModule),
		typeof(AbpSettingManagementApplicationModule)
		)]
	public class BookModule : AbpModule
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
}