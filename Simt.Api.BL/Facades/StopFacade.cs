using Simt.Api.BL.Mappers;
using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

namespace Simt.Api.BL.Facades;

public class StopFacade : FacadeBase<StopRepository, StopEntity, StopListModel, StopDetailModel>
{
    private readonly StopRepository _stopRepository;
    private readonly IModelMapper<StopEntity, StopListModel, StopDetailModel> _modelStopper;
    private readonly LineModelMapper _lineModelMapper;

    public StopFacade(
        StopRepository repository, 
        IModelMapper<StopEntity, StopListModel, StopDetailModel> modelStopper,
        LineModelMapper lineModelMapper) 
        : base(repository, modelStopper)
    {
        _stopRepository = repository;
        _modelStopper = modelStopper;
        _lineModelMapper = lineModelMapper;
    }
    
    public async Task<List<LineListModel>?> GetAllLinesForStopByIdAsync(Guid stopId)
    {
        StopEntity? entity = await Repository.GetByIdAsync(stopId);

        if (entity == null)
        {
            return null;
        }
        
        // Use a HashSet to track Line IDs that have already been added
        var addedLineIds = new HashSet<Guid>();
        List<LineListModel> lineListModelList = [];
        
        foreach (var platform in entity.Platforms)
        {
            foreach (var routeStop in platform.RouteStops)
            {
                var line = routeStop.Route.Line;
                if (addedLineIds.Add(line.Id)) // Add to HashSet and check for duplicates
                {
                    lineListModelList.Add(_lineModelMapper.MapToListModel(line));
                }
            }
        }
        return lineListModelList;
    }
}