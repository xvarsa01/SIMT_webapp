using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class PlayerFacade : FacadeBase<PlayerRepository, PlayerEntity, PlayerListModel, PlayerProfileModel>
{
    private readonly PlayerRepository _playerRepository;
    private readonly ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel> _modelMapper;
    
    public PlayerFacade(
        PlayerRepository repository,
        ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel> modelMapper)
        : base(repository, modelMapper)
    {
        _playerRepository = repository;
        _modelMapper = modelMapper;
    }
    
    
    
    
    
}