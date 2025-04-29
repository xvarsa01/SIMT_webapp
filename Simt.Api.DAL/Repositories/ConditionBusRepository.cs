using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionBusRepository(SimtDbContext dbContext) : RepositoryBase<ConditionBusEntity>(dbContext)
{
    private readonly DbSet<ConditionBusEntity> _dbSet = dbContext.Set<ConditionBusEntity>();
    
}