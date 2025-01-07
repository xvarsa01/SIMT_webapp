using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;

namespace Simt.Api.DAL;

public class SimtDbContext (DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<MapEntity> Map => Set<MapEntity>();
    public DbSet<StopEntity> Stop => Set<StopEntity>();
    public DbSet<RouteEntity> Route => Set<RouteEntity>();
    public DbSet<RoutePlatformEntity> RouteStop => Set<RoutePlatformEntity>();
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
            .HasMany(e => e.RouteStops)
            .WithOne(e => e.Route)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        
        modelBuilder.Entity<StopEntity>()
            .HasMany(e => e.Platforms)
            .WithOne(e => e.ParentStop)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        modelBuilder.Entity<PlatformEntity>()
            .HasMany(e => e.RouteStops)
            .WithOne(e => e.Platform)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        
        modelBuilder.Entity<PlatformEntity>()
            .HasMany(e => e.RouteStarts)
            .WithOne(e => e.StartPlatform)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        
        modelBuilder.Entity<PlatformEntity>()
            .HasMany(e => e.RouteFinals)
            .WithOne(e => e.FinalPlatform)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        
        if (seedDemoData)
        {
            StopSeeds.Seed(modelBuilder);
            PlatformSeeds.Seed(modelBuilder);
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