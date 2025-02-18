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
        IModelMapper<PlayerEntity, PlayerListModel, PlayerDetailModel, PlayerCreationModel> modelMapper)
        : base(repository, modelMapper)
    {
        _playerRepository = repository;
        _modelMapper = modelMapper;
    }
    
    public virtual async Task<List<PlayerListModel>> GetAllAsync(string searchTerm)
    {
        List<PlayerEntity> entities = await Repository.GetAllAsync(searchTerm);
        
        var models =  ModelMapper.MapToListModel(entities);
        return models;
    }
    
    public async Task<PlayerDetailModel?> GetByNickAsync(string nick)
    {
        PlayerEntity? entity = await Repository.GetByNickAsync(nick);

        return entity is null
            ? null
            : ModelMapper.MapToDetailModel(entity);
    }
}