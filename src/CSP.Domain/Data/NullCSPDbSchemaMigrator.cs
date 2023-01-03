using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.Data;

/* This is used if database provider does't define
 * ICSPDbSchemaMigrator implementation.
 */
public class NullCSPDbSchemaMigrator : ICSPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
