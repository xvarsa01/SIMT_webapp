using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class LineRepository(SimtDbContext dbContext) : RepositoryBase<LineEntity>(dbContext)
{
    
}