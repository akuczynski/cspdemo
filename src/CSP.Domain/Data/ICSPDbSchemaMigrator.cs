using System.Threading.Tasks;

namespace CSP.Data;

public interface ICSPDbSchemaMigrator
{
    Task MigrateAsync();
}
