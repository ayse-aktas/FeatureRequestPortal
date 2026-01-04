using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FeatureRequestPortal.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class FeatureRequestPortalDbContextFactory : IDesignTimeDbContextFactory<FeatureRequestPortalDbContext>
{
    public FeatureRequestPortalDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        FeatureRequestPortalEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<FeatureRequestPortalDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));
        
        return new FeatureRequestPortalDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FeatureRequestPortal.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
