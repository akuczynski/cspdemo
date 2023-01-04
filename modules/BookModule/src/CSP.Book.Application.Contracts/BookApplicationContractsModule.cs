using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace CSP.Book;

[DependsOn(
    typeof(BookDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class BookApplicationContractsModule : AbpModule
{

}
