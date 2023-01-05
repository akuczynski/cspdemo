using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using CSP.Book.EntityFrameworkCore;
using System.IO;
using Volo.Abp.Data;
using CSP.ModuleContracts;
using System.Runtime;
using Volo.Abp;
using CSP.Core; 

namespace CSP.EntityFrameworkCore;

[DependsOn(
    typeof(CSPDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(BookEntityFrameworkCoreModule)
    )]
public class CSPEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CSPEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
		var appSettings = context.Services.GetRequiredServiceLazy<IApplicationSettings>();

		Configure<AbpDbConnectionOptions>(options =>
		{
            // this is required to make app working on different OS 
            if (appSettings.Value.DatabaseFilePath != null)
            {
                options.ConnectionStrings.Default = $"DataSource={appSettings.Value.DatabaseFilePath}";
            }
		});

		context.Services.AddAbpDbContext<CSPDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

		Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also CSPMigrationsDbContextFactory for EF Core tooling. */
             
            options.UseSqlite();
        });
    } 
}
