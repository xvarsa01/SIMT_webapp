using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class VehicleRepository(SimtDbContext dbContext) : RepositoryBase<VehicleEntity>(dbContext)
{
    
}