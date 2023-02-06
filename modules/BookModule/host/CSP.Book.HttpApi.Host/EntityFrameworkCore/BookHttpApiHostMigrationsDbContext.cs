using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CSP.Book.EntityFrameworkCore;

public class BookHttpApiHostMigrationsDbContext : AbpDbContext<BookHttpApiHostMigrationsDbContext>
{
    public BookHttpApiHostMigrationsDbContext(DbContextOptions<BookHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureBook();
    }
}
