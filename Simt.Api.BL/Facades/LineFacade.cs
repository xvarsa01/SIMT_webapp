using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class LineFacade : FacadeBase<LineRepository, LineEntity, LineListModel, LineDetailModel, LineCreationModel>
{
    private readonly LineRepository _lineRepository;
    private readonly IModelMapper<LineEntity, LineListModel, LineDetailModel, LineCreationModel> _modelMapper;

    public LineFacade(
        LineRepository repository, 
        IModelMapper<LineEntity, LineListModel, LineDetailModel, LineCreationModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _lineRepository = repository;
        _modelMapper = modelMapper;
    }
    
    public async Task<List<LineListModel>> GetAllByMapAsync(Guid mapId)
    {
        List<LineEntity> entities = await _lineRepository.GetAllByMapAsync(mapId);
        
        var models =  _modelMapper.MapToListModel(entities);
        return models;
    }
    
    public override async Task<Guid?> UpdateAsync(LineCreationModel model)
    {
        GuardCollectionsAreNotSet(model);
        LineEntity entity = _modelMapper.MapToEntity(model);
        
        Guid? updatedEntityId = await _lineRepository.UpdateAsync(entity);
        return updatedEntityId;
    }
}