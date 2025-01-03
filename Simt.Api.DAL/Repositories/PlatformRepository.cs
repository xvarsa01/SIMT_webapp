using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class PlatformRepository(SimtDbContext dbContext) : RepositoryBase<PlatformEntity>(dbContext)
{
    
}