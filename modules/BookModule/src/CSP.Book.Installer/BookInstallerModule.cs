using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CSP.Book;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class BookInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookInstallerModule>();
        });
    }
}
