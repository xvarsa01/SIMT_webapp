using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;

namespace Simt.DAL;

public class SimtDbContext(DbContextOptions contextOptions, bool seedDemoData = false): DbContext (contextOptions)
{
    public DbSet<HracEntita> Hraci => Set<HracEntita>();
    public DbSet<LinkaEntita> Linky => Set<LinkaEntita>();
    public DbSet<SpojEntita> Spoje => Set<SpojEntita>();
    public DbSet<VozidloEntita> Vozidla => Set<VozidloEntita>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HracEntita>()
            .HasMany<SpojEntita>(i => i.Spoje)
            .WithOne(s => s.Hrac);
        
        modelBuilder.Entity<LinkaEntita>()
            .HasMany<SpojEntita>(i => i.Spoje)
            .WithOne(s => s.Linka);
        
        modelBuilder.Entity<VozidloEntita>()
            .HasMany<SpojEntita>(i => i.Spoje)
            .WithOne(s => s.Vozidlo);

    }
}