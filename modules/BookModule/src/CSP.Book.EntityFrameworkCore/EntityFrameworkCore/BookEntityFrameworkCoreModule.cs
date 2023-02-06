using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CSP.Book.EntityFrameworkCore;

[DependsOn(
    typeof(BookDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BookEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BookDbContext>(options =>
        {
			/* Add custom repositories here. Example:
			 * options.AddRepository<Question, EfCoreQuestionRepository>();
			 */

			/* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
			options.AddDefaultRepositories(includeAllEntities: true);
		});
    }
}
