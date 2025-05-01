using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class PlayerFacade : FacadeBase<PlayerRepository, PlayerEntity, PlayerListModel, PlayerDetailModel, PlayerCreationModel>
{
    private readonly PlayerRepository _playerRepository;
    private readonly IModelMapper<PlayerEntity, PlayerListModel, PlayerDetailModel, PlayerCreationModel> _modelMapper;
    
    public PlayerFacade(
        PlayerRepository repository,
        IModelMapper<PlayerEntity, PlayerListModel, PlayerDetailModel, PlayerCreationModel> modelMapper,
        IModelMapper<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel> conBusModelMapper,
        IModelMapper<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel> conTramModelMapper
        )
        : base(repository, modelMapper)
    {
        _playerRepository = repository;
        _modelMapper = modelMapper;
    }
    
    public async Task<List<PlayerListModel>> GetAllAsync(string searchTerm)
    {
        List<PlayerEntity> entities = await _playerRepository.GetAllAsync(searchTerm);
        
        var models =  _modelMapper.MapToListModel(entities);
        return models;
    }
    
    public async Task<PlayerDetailModel?> GetByNickAsync(string nick)
    {
        PlayerEntity? entity = await _playerRepository.GetByNickAsync(nick);

        return entity is null
            ? null
            : _modelMapper.MapToDetailModel(entity);
    }
    
    public override async Task<Guid> CreateAsync(PlayerCreationModel model)
    {
        GuardCollectionsAreNotSet(model);
        PlayerEntity entity = ModelMapper.MapToEntity(model);

        ConditionBusEntity conditionBusEntity = ConditionBusEntity.Empty;
        ConditionTramEntity conditionTramEntity = ConditionTramEntity.Empty;
        
        entity.ConditionBusId = conditionBusEntity.Id;
        entity.ConditionTramId = conditionTramEntity.Id;

        Guid createdEntityId = await _playerRepository.InsertAsync(entity, conditionTramEntity, conditionBusEntity);
        return createdEntityId;
    }
}