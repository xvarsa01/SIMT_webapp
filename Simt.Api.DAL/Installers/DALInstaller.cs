using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simt.Api.DAL.Factories;
using Simt.Api.DAL.Repositories;

namespace Simt.Api.DAL.Installers;

public static class DALInstaller
{
    public static void AddDALServices(this IServiceCollection services, DbConfiguration dbConfig)
    {
        if (dbConfig is null)
        {
            throw new InvalidOperationException("No persistence provider configured");
        }

        if (dbConfig.Sqlite.Enabled && dbConfig.SqlServer.Enabled)
        {
            throw new InvalidOperationException("Both database providers enabled in Simt.Api.App appsettings.json . Choose just one of them.");
        }
        
        if (! dbConfig.Sqlite.Enabled && ! dbConfig.SqlServer.Enabled)
        {
            throw new InvalidOperationException("No database provider enabled in Simt.Api.App appsettings.json . Choose just one of them.");
        }
        
        if (dbConfig.Sqlite.Enabled)
        {
            var dbName = dbConfig.Sqlite.DatabaseName
                         ?? throw new ArgumentException("The connection string is missing");
        
            var dataSourceString = "Data Source=";
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "true")
            {
                dataSourceString = "Data Source=../../../";
            }
        
            services.AddSingleton<IDbContextFactory<SimtDbContext>>(_ =>
                new DbContextSqLiteFactory(dbName, dbConfig.Sqlite.SeedDemoData));
            services.AddDbContext<SimtDbContext>(options =>
                options.UseSqlite(dataSourceString+dbName));
        }
        else if (dbConfig.SqlServer.Enabled)
        {
            
        }
        
        services.AddSingleton(dbConfig);
        services.Scan(selector => selector
            .FromAssemblyOf<SimtDbContext>() 
            .AddClasses(filter => filter.AssignableTo(typeof(IRepository<>))) 
            .AsSelf()
            .WithScopedLifetime());
    }
}
