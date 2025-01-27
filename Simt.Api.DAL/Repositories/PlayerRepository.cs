using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class PlayerRepository(SimtDbContext dbContext) : RepositoryBase<PlayerEntity>(dbContext)
{
    private readonly DbSet<PlayerEntity> _dbSet = dbContext.Set<PlayerEntity>();
    
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
}