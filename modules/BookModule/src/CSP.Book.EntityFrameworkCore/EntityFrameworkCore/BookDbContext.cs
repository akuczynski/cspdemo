using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CSP.Book.EntityFrameworkCore;

[ConnectionStringName(BookDbProperties.ConnectionStringName)]
public class BookDbContext : AbpDbContext<BookDbContext>, IBookDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<Book>  Books { get; set; }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBook();
    }
}
