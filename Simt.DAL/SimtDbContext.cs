using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;

namespace Simt.DAL;

public class SimtDbContext(DbContextOptions contextOptions, bool seedDemoData = false): DbContext (contextOptions)
{
    public DbSet<PlayerEntita> Players => Set<PlayerEntita>();
    public DbSet<LineEntity> Lines => Set<LineEntity>();
    public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
    public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerEntita>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Player);
        
        modelBuilder.Entity<LineEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Line);
        
        modelBuilder.Entity<VehicleEntity>()
            .HasMany<ServiceEntity>(i => i.Services)
            .WithOne(s => s.Vehicle);

    }
}