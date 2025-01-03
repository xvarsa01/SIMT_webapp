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
    public DbSet<MapEntity> Map => Set<MapEntity>();
    public DbSet<StationEntity> Station => Set<StationEntity>();
    public DbSet<RouteEntity> Route => Set<RouteEntity>();
    public DbSet<RouteStopEntity> RouteStop => Set<RouteStopEntity>();
    public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
    public DbSet<LineEntity> Lines => Set<LineEntity>();
    public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
    public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MapEntity>()
            .HasMany(e => e.Lines)
            .WithOne(e => e.Map)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        modelBuilder.Entity<LineEntity>()
            .HasMany(e => e.Routes)
            .WithOne(e => e.Line)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        modelBuilder.Entity<RouteEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Route)
            .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        
        modelBuilder.Entity<PlayerEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Player);
        
        modelBuilder.Entity<VehicleEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Vehicle);

        
        modelBuilder.Entity<RouteEntity>()
            .HasOne(e => e.StartStop);
        modelBuilder.Entity<RouteEntity>()
            .HasOne(e => e.FinalStop);
        
        modelBuilder.Entity<RouteEntity>()
            .HasMany(e => e.Stops)
            .WithOne(e => e.Route)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        
        modelBuilder.Entity<StationEntity>()
            .HasMany(e => e.LineRouteStops)
            .WithOne(e => e.Stop)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        
        if (true)
        {
            StationSeeds.Seed(modelBuilder);
            PlayerSeeds.Seed(modelBuilder); 
            LineSeeds.Seed(modelBuilder);
            MapSeeds.Seed(modelBuilder);
            RouteSeeds.Seed(modelBuilder);
            RouteStopSeeds.Seed(modelBuilder);
            VehicleSeeds.Seed(modelBuilder);
            ServiceSeeds.Seed(modelBuilder);
        }
    }
}