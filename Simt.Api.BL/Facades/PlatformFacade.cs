using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class PlatformFacade : FacadeBase<PlatformRepository, PlatformEntity, PlatformModel, PlatformModel>
{
    private readonly PlatformRepository _platformRepository;
    private readonly IModelMapper<PlatformEntity, PlatformModel, PlatformModel> _modelMapper;

    public PlatformFacade(
        PlatformRepository repository, 
        IModelMapper<PlatformEntity, PlatformModel, PlatformModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _platformRepository = repository;
        _modelMapper = modelMapper;
    }
}