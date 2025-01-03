using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class VehicleFacade : FacadeBase<VehicleRepository, VehicleEntity, VehicleListModel, VehicleDetailModel>
{
    private readonly VehicleRepository _vehicleRepository;
    private readonly IModelMapper<VehicleEntity, VehicleListModel, VehicleDetailModel> _modelMapper;

    public VehicleFacade(
        VehicleRepository repository, 
        IModelMapper<VehicleEntity, VehicleListModel, VehicleDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _vehicleRepository = repository;
        _modelMapper = modelMapper;
    }
}