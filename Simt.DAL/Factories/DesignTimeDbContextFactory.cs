using Microsoft.EntityFrameworkCore.Design;

namespace Simt.DAL.Factories;

/// <summary>
///     EF Core CLI migration generation uses this DbContext to create model and migration
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SimtDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new("simt.db");

    public SimtDbContext CreateDbContext(string[] args)
    {
        return _dbContextSqLiteFactory.CreateDbContext();
    }
}
