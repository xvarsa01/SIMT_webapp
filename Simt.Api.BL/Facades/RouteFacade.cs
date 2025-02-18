using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class RouteFacade : FacadeBase<RouteRepository, RouteEntity, RouteListModel, RouteDetailModel, RouteDetailModel>
{
    private readonly RouteRepository _routeRepository;
    private readonly IModelMapper<RouteEntity, RouteListModel, RouteDetailModel, RouteDetailModel> _modelMapper;

    public RouteFacade(
        RouteRepository repository, 
        IModelMapper<RouteEntity, RouteListModel, RouteDetailModel, RouteDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _routeRepository = repository;
        _modelMapper = modelMapper;
    }
}