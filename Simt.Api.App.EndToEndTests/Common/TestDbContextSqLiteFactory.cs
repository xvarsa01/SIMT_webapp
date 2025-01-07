using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL;

namespace Simt.Api.App.EndToEndTests.Common;

public class TestDbContextSqLiteFactory : IDbContextFactory<SimtDbContext>
{
    private readonly bool _seedTestingData;
    private readonly DbContextOptionsBuilder<TestSimtDbContext> _contextOptionsBuilder = new();

    public TestDbContextSqLiteFactory(string databaseName, bool seedTestingData = false)
    {
        _seedTestingData = seedTestingData;

        _contextOptionsBuilder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        ////Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        //_contextOptionsBuilder.EnableSensitiveDataLogging();
        //_contextOptionsBuilder.LogTo(Console.WriteLine);
    }

    public SimtDbContext CreateDbContext()
    {
        return new TestSimtDbContext(_contextOptionsBuilder.Options, _seedTestingData);
    }
}
