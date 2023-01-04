using Volo.Abp;
using Volo.Abp.MongoDB;

namespace CSP.Book.MongoDB;

public static class BookMongoDbContextExtensions
{
    public static void ConfigureBook(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
