using Microsoft.EntityFrameworkCore;

namespace Simt.Api.DAL.Factories;

public class DbContextSqLiteFactory : IDbContextFactory<SimtDbContext>
{
    private readonly bool _seedTestingData;
    private readonly DbContextOptionsBuilder<SimtDbContext> _contextOptionsBuilder = new();

    public DbContextSqLiteFactory(string databaseName, bool seedTestingData = false)
    {
        _seedTestingData = seedTestingData;

        _contextOptionsBuilder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        ////Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        //_contextOptionsBuilder.EnableSensitiveDataLogging();
        //_contextOptionsBuilder.LogTo(Console.WriteLine);
    }

    public SimtDbContext CreateDbContext()
    {
        return new SimtDbContext(_contextOptionsBuilder.Options, _seedTestingData);
    }
}
