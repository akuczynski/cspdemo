using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CSP.Book.MongoDB;

[ConnectionStringName(BookDbProperties.ConnectionStringName)]
public interface IBookMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
