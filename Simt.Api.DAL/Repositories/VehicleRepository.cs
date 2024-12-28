using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public class VehicleRepository(SimtDbContext dbContext) : RepositoryBase<VehicleEntity>(dbContext)
{
    
}