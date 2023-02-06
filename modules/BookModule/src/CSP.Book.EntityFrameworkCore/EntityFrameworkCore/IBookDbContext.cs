using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CSP.Book.EntityFrameworkCore;

[ConnectionStringName(BookDbProperties.ConnectionStringName)]
public interface IBookDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
