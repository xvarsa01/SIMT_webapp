using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public class LineRepository(SimtDbContext dbContext) : RepositoryBase<LineEntity>(dbContext)
{
    
}