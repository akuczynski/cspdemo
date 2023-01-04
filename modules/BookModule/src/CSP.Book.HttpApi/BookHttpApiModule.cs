using Localization.Resources.AbpUi;
using CSP.Book.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CSP.Book;

[DependsOn(
    typeof(BookApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BookHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BookHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BookResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
