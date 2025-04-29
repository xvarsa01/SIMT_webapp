using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class VehicleFacade : FacadeBase<VehicleRepository, VehicleEntity, VehicleListModel, VehicleDetailModel, VehicleDetailModel>
{
    private readonly VehicleRepository _vehicleRepository;
    private readonly IModelMapper<VehicleEntity, VehicleListModel, VehicleDetailModel, VehicleDetailModel> _modelMapper;

    public VehicleFacade(
        VehicleRepository repository, 
        IModelMapper<VehicleEntity, VehicleListModel, VehicleDetailModel, VehicleDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _vehicleRepository = repository;
        _modelMapper = modelMapper;
    }
    
    public async Task<List<VehicleListModel>> GetAllBusesAsync()
    {
        List<VehicleEntity> entities = await Repository.GetAllBusesAsync();
        
        var models =  ModelMapper.MapToListModel(entities);
        return models;
    }
    public async Task<List<VehicleListModel>> GetAllTrolleybusesAsync()
    {
        List<VehicleEntity> entities = await Repository.GetAllTrolleybusesAsync();
        
        var models =  ModelMapper.MapToListModel(entities);
        return models;
    }
    public async Task<List<VehicleListModel>> GetAllTramsAsync()
    {
        List<VehicleEntity> entities = await Repository.GetAllTramsAsync();
        
        var models =  ModelMapper.MapToListModel(entities);
        return models;
    }
}