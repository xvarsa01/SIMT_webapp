using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ConditionBusFacade : FacadeBase<ConditionBusRepository, ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel>
{
    private readonly ConditionBusRepository _conditionBusRepository;
    private readonly PlayerRepository _playerRepository;
    private readonly IModelMapper<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel> _modelMapper;

    public ConditionBusFacade(
        ConditionBusRepository repository,
        PlayerRepository playerRepository,
        IModelMapper<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _conditionBusRepository = repository;
        _playerRepository = playerRepository;
        _modelMapper = modelMapper;
    }

    public async Task<ConditionBusModel?> GetByPlayerIdAsync(Guid playerId)
    {
        PlayerEntity? playerEntity = await _playerRepository.GetByIdAsync(playerId);
        if (playerEntity is null)
        {
            return null;
        }
        ConditionBusEntity? entity = await _conditionBusRepository.GetByIdAsync(playerEntity.ConditionBusId);
        
        return entity is null
            ? null
            : _modelMapper.MapToDetailModel(entity);
    }
}