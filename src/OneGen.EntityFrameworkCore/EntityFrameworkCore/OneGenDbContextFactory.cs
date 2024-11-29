using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OneGen.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OneGenDbContextFactory : IDesignTimeDbContextFactory<OneGenDbContext>
{
    public OneGenDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        OneGenEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<OneGenDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new OneGenDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OneGen.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
