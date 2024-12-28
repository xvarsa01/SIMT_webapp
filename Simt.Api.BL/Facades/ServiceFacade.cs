using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.DAL.entities;
using Simt.DAL.Repositories;

namespace Simt.BL.Facades;

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