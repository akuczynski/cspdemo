using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CSP.Book;

[DependsOn(
    typeof(BookApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BookHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BookApplicationContractsModule).Assembly,
            BookRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookHttpApiClientModule>();
        });

    }
}
