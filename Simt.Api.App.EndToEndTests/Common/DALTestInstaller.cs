using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL;
using Simt.Api.DAL.Factories;
using Simt.Api.DAL.Installers;
using Simt.Api.DAL.Repositories;

namespace Simt.Api.App.EndToEndTests.Common;

public class DALTestInstaller : IDALInstaller
{
    public void AddDALServices(IServiceCollection services, DbConfiguration dbConfig)
    {
        
        Directory.SetCurrentDirectory("../../../");
        // var dataSourceString = "Data Source=../../../";
        
        dbConfig.Sqlite.DatabaseName = "../Simt.Api.DAL/test.db";
        var dbName = dbConfig.Sqlite.DatabaseName;
        
        services.AddSingleton<IDbContextFactory<SimtDbContext>>(_ =>
            new TestDbContextSqLiteFactory(dbName, dbConfig.Sqlite.SeedDemoData));
        services.AddDbContext<SimtDbContext>(options =>
            options.UseSqlite("Data Source="+dbName));
        
        services.AddSingleton(dbConfig);
        services.Scan(selector => selector
            .FromAssemblyOf<SimtDbContext>() 
            .AddClasses(filter => filter.AssignableTo(typeof(IRepository<>))) 
            .AsSelf()
            .WithScopedLifetime());
    }
}
