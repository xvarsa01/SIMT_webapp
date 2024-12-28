using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public class ServiceRepository(SimtDbContext dbContext) : RepositoryBase<ServiceEntity>(dbContext)
{
    
}