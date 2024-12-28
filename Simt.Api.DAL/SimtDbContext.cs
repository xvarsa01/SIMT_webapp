using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;

namespace Simt.Api.DAL;

public class SimtDbContext : DbContext
{
    public SimtDbContext(DbContextOptions<SimtDbContext> options, bool seedDemoData = false) : base(options)
    {
        // _seedDemoData = seedDemoData;
    }
    public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
    public DbSet<LineEntity> Lines => Set<LineEntity>();
    public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
    public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Player);
        
        modelBuilder.Entity<RouteEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Route);
        
        modelBuilder.Entity<VehicleEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Vehicle);

        
        if (true)
        {
            PlayerSeeds.Seed(modelBuilder);
            LineSeeds.Seed(modelBuilder);
            VehicleSeeds.Seed(modelBuilder);
            ServiceSeeds.Seed(modelBuilder);
        }
    }
}