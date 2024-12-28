using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.DAL.entities;
using Simt.DAL.Repositories;

namespace Simt.BL.Facades;

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