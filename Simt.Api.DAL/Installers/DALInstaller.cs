using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.DependencyInjection;
using Simt.Api.DAL.Factories;
using Simt.Api.DAL.Repositories;

namespace Simt.Api.DAL.Installers;

public class DALInstaller : IDALInstaller
{
    public void AddDALServices(IServiceCollection services, DbConfiguration dbConfig)
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
            var dataSourceString = "Data Source=";

            var dbName = dbConfig.Sqlite.DatabaseName
                         ?? throw new ArgumentException("The connection string is missing");
        
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
