using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class VehicleRepository(SimtDbContext dbContext) : RepositoryBase<VehicleEntity>(dbContext)
{
    private readonly DbSet<VehicleEntity> _dbSet = dbContext.Set<VehicleEntity>();
    
    public async Task<List<VehicleEntity>> GetAllBusesAsync()
    {
        return await _dbSet
            .Where(vehicle => vehicle.Traction == Traction.Bus)
            .ToListAsync();
    }
    public async Task<List<VehicleEntity>> GetAllTrolleybusesAsync()
    {
        return await _dbSet
            .Where(vehicle => vehicle.Traction == Traction.Trolleybus)
            .ToListAsync();
    }
    public async Task<List<VehicleEntity>> GetAllTramsAsync()
    {
        return await _dbSet
            .Where(vehicle => vehicle.Traction == Traction.Tram)
            .ToListAsync();
    }
    
}