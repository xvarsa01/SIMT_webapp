using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.DAL.entities;
using Simt.DAL.Repositories;

namespace Simt.BL.Facades;

public class PlayerFacade : FacadeBase<IRepository<PlayerEntity>, PlayerEntity, PlayerListModel, PlayerProfileModel>
{
    private readonly IRepository<PlayerEntity> playerRepository;
    private readonly ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel> modelMapper;
    
    public PlayerFacade(
        IRepository<PlayerEntity> repository,
        ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel> modelMapper)
        :base(repository, modelMapper)
    {
        playerRepository = repository;
        this.modelMapper = modelMapper;
    }
    
    
    
    
    
}