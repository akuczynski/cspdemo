using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CSP.Book;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class BookConsoleApiClientModule : AbpModule
{

}
