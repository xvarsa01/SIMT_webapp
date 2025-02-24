using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class ConditionTramFacade : FacadeBase<ConditionTramRepository, ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel>
{
    private readonly ConditionTramRepository _conditionTramRepository;
    private readonly IModelMapper<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel> _modelMapper;

    public ConditionTramFacade(
        ConditionTramRepository repository, 
        IModelMapper<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _conditionTramRepository = repository;
        _modelMapper = modelMapper;
    }
}