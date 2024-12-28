using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ServiceFacade : FacadeBase<ServiceRepository, ServiceEntity, ServiceListModel, ServiceDetailModel>
{
    private readonly ServiceRepository _serviceRepository;
    private readonly ModelMapperBase<ServiceEntity, ServiceListModel, ServiceDetailModel> _modelMapper;

    public ServiceFacade(
        ServiceRepository repository, 
        ModelMapperBase<ServiceEntity, ServiceListModel, ServiceDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _serviceRepository = repository;
        _modelMapper = modelMapper;
    }
}