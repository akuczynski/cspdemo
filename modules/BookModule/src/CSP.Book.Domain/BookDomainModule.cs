using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace CSP.Book;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(BookDomainSharedModule)
)]
public class BookDomainModule : AbpModule
{

}
