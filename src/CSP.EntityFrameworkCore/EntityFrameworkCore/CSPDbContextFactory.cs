using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CSP.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CSPDbContextFactory : IDesignTimeDbContextFactory<CSPDbContext>
{
    private string _appDataDir;

    public CSPDbContextFactory()
    {
    }
	public CSPDbContext CreateDbContext(string[] args)
    {
        CSPEfCoreEntityExtensionMappings.Configure();

		var configuration = BuildConfiguration();

		var builder = new DbContextOptionsBuilder<CSPDbContext>()
			.UseSqlite(configuration.GetConnectionString("Default"));

		return new CSPDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CSP.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
