using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ConditionBusFacade : FacadeBase<ConditionBusRepository, ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel>
{
    private readonly ConditionBusRepository _conditionBusRepository;
    private readonly IModelMapper<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel> _modelMapper;

    public ConditionBusFacade(
        ConditionBusRepository repository, 
        IModelMapper<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _conditionBusRepository = repository;
        _modelMapper = modelMapper;
    }
    
    
}