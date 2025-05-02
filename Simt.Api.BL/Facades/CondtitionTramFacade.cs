using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ConditionTramFacade : FacadeBase<ConditionTramRepository, ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel>
{
    private readonly ConditionTramRepository _conditionTramRepository;
    private readonly PlayerRepository _playerRepository;
    private readonly IModelMapper<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel> _modelMapper;

    public ConditionTramFacade(
        ConditionTramRepository repository,
        PlayerRepository playerRepository,
        IModelMapper<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _conditionTramRepository = repository;
        _playerRepository = playerRepository;
        _modelMapper = modelMapper;
    }
    
    public async Task<ConditionTramModel?> GetByPlayerIdAsync(Guid playerId)
    {
        PlayerEntity? playerEntity = await _playerRepository.GetByIdAsync(playerId);
        if (playerEntity is null)
        {
            return null;
        }
        ConditionTramEntity? entity = await _conditionTramRepository.GetByIdAsync(playerEntity.ConditionTramId);
        
        return entity is null
            ? null
            : _modelMapper.MapToDetailModel(entity);
    }
    
    public override Task<List<ConditionTramModel>> GetAllAsync()
    {
        throw new NotImplementedException("This method is unsupported. Use the overload with paging.");
    }
    
    public override Task<Guid> CreateAsync(ConditionTramModel model)
    {
        throw new NotImplementedException("This method is unsupported. Condition is created along Player in PlayerFacade");
    }
    
    public override Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException("This method is unsupported. Condition is deleted along Player in PlayerFacade");
    }
}