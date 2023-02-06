using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CSP.Book.EntityFrameworkCore;

public class BookHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BookHttpApiHostMigrationsDbContext>
{
    public BookHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Book"));

        return new BookHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
