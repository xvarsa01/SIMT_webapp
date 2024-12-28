using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class ServiceRepository(SimtDbContext dbContext) : RepositoryBase<ServiceEntity>(dbContext)
{
    
}