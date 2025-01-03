using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ServiceFacade : FacadeBase<ServiceRepository, ServiceEntity, ServiceListModel, ServiceDetailModel>
{
    private readonly ServiceRepository _serviceRepository;
    private readonly IModelMapper<ServiceEntity, ServiceListModel, ServiceDetailModel> _modelMapper;

    public ServiceFacade(
        ServiceRepository repository, 
        IModelMapper<ServiceEntity, ServiceListModel, ServiceDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _serviceRepository = repository;
        _modelMapper = modelMapper;
    }

    public async Task<List<ServiceDetailModel>> GetAllActiveAsync()
    {
        List<ServiceEntity> entities = await _serviceRepository.GetAllActiveAsync();
        return _modelMapper.MapToDetailModel(entities);
    }
    
    public async Task<List<ServiceDetailModel>> GetAllForPlayerAsync(Guid playerId, int pageNumber, int pageSize)
    {
        List<ServiceEntity> entities = await _serviceRepository.GetAllForPlayerAsync(playerId, pageNumber, pageSize);
        return _modelMapper.MapToDetailModel(entities);
    }

}