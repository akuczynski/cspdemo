using Volo.Abp.Modularity;

namespace CSP.Book;

[DependsOn(
    typeof(BookApplicationModule),
    typeof(BookDomainTestModule)
    )]
public class BookApplicationTestModule : AbpModule
{

}
