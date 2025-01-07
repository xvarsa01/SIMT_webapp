using Microsoft.EntityFrameworkCore;
using Simt.Api.App.EndToEndTests.TestSeeds;
using Simt.Api.DAL;

namespace Simt.Api.App.EndToEndTests.Common;

public class TestSimtDbContext(DbContextOptions contextOptions, bool seedTestingData)
    : SimtDbContext(contextOptions, seedDemoData: false)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        if (true)
        {
            StopTestSeeds.Seed(modelBuilder);
            PlatformTestSeeds.Seed(modelBuilder);
            PlayerTestSeeds.Seed(modelBuilder); 
            LineTestSeeds.Seed(modelBuilder);
            MapTestSeeds.Seed(modelBuilder);
            RouteTestSeeds.Seed(modelBuilder);
            RouteStopTestSeeds.Seed(modelBuilder);
            VehicleTestSeeds.Seed(modelBuilder);
            ServiceTestSeeds.Seed(modelBuilder);
        }
    }
}