using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class RouteFacade : FacadeBase<RouteRepository, RouteEntity, RouteListModel, RouteDetailModel, RouteCreationModel>
{
    private readonly RouteRepository _routeRepository;
    private readonly IModelMapper<RouteEntity, RouteListModel, RouteDetailModel, RouteCreationModel> _modelMapper;

    public RouteFacade(
        RouteRepository repository, 
        IModelMapper<RouteEntity, RouteListModel, RouteDetailModel, RouteCreationModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _routeRepository = repository;
        _modelMapper = modelMapper;
    }
}