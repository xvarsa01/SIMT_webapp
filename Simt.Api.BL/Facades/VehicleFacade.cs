using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.DAL.entities;
using Simt.DAL.Repositories;

namespace Simt.BL.Facades;

public class VehicleFacade : FacadeBase<VehicleRepository, VehicleEntity, VehicleListModel, VehicleDetailModel>
{
    private readonly VehicleRepository _vehicleRepository;
    private readonly ModelMapperBase<VehicleEntity, VehicleListModel, VehicleDetailModel> _modelMapper;

    public VehicleFacade(
        VehicleRepository repository, 
        ModelMapperBase<VehicleEntity, VehicleListModel, VehicleDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _vehicleRepository = repository;
        _modelMapper = modelMapper;
    }
}