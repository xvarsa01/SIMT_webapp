using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class MapFacade : FacadeBase<MapRepository, MapEntity, MapListModel, MapDetailModel>
{
    private readonly MapRepository _mapRepository;
    private readonly IModelMapper<MapEntity, MapListModel, MapDetailModel> _modelMapper;

    public MapFacade(
        MapRepository repository, 
        IModelMapper<MapEntity, MapListModel, MapDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _mapRepository = repository;
        _modelMapper = modelMapper;
    }
}