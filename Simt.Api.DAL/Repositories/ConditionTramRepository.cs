using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionTramRepository(SimtDbContext dbContext) : RepositoryBase<ConditionTramEntity>(dbContext)
{
    private readonly DbSet<ConditionTramEntity> _dbSet = dbContext.Set<ConditionTramEntity>();
    
}