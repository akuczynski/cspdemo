using CSP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CSP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CSPEntityFrameworkCoreModule),
    typeof(CSPApplicationContractsModule)
    )]
public class CSPDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
