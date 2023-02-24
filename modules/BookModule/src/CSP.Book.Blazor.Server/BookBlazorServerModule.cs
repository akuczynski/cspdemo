using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace CSP.Book.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(BookBlazorModule)
    )]
public class BookBlazorServerModule : AbpModule
{

}
