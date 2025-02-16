using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class LineFacade : FacadeBase<LineRepository, LineEntity, LineListModel, LineDetailModel>
{
    private readonly LineRepository _lineRepository;
    private readonly IModelMapper<LineEntity, LineListModel, LineDetailModel> _modelMapper;

    public LineFacade(
        LineRepository repository, 
        IModelMapper<LineEntity, LineListModel, LineDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _lineRepository = repository;
        _modelMapper = modelMapper;
    }
    
    public async Task<List<LineListModel>> GetAllByMapAsync(Guid mapId)
    {
        List<LineEntity> entities = await Repository.GetAllByMapAsync(mapId);
        
        var models =  ModelMapper.MapToListModel(entities);
        return models;
    }
}