using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class PlayerRepository(SimtDbContext dbContext) : RepositoryBase<PlayerEntity>(dbContext)
{
    
}