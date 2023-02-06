using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CSP.Book.MongoDB;

[ConnectionStringName(BookDbProperties.ConnectionStringName)]
public class BookMongoDbContext : AbpMongoDbContext, IBookMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureBook();
    }
}
