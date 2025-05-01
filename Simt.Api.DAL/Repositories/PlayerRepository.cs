using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class PlayerRepository(SimtDbContext dbContext, ConditionBusRepository conditionBusRepository, ConditionTramRepository conditionTramRepository) : RepositoryBase<PlayerEntity>(dbContext)
{
    private readonly DbSet<PlayerEntity> _dbSet = dbContext.Set<PlayerEntity>();
    public override Task<List<PlayerEntity>> GetAllAsync()
    {
        throw new NotImplementedException("This method is unsupported. Use the overload with paging.");
    }
    public async Task<List<PlayerEntity>> GetAllAsync(string searchTerm)
    {
        return await _dbSet
            .Where(player => player.Nick.ToLower().Contains(searchTerm.ToLower()))
            .ToListAsync();
    }
    
    public async Task<PlayerEntity?> GetByNickAsync(string nick)
    {
        return await _dbSet.SingleOrDefaultAsync(entity => entity.Nick == nick);
    }

    public override Task<Guid> InsertAsync(PlayerEntity entity)
    {
        throw new NotImplementedException("This method is unsupported. Use the overload that will create ConditionTramEntity and ConditionBusEntity as well.");
    }

    public async Task<Guid> InsertAsync(PlayerEntity entity, ConditionTramEntity conditionTramEntity, ConditionBusEntity conditionBusEntity)
    {
        var createdEntity = (await _dbSet.AddAsync(entity)).Entity;

        await conditionBusRepository.InsertAsync(conditionBusEntity);
        await conditionTramRepository.InsertAsync(conditionTramEntity);
        
        await dbContext.SaveChangesAsync();
        return createdEntity.Id;
    }
    
}