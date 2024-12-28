using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public class PlayerRepository(SimtDbContext dbContext) : RepositoryBase<PlayerEntity>(dbContext)
{
    
}