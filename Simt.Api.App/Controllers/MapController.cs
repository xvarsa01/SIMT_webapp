using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("Map")]
public class MapController : ControllerBase
{
    private readonly MapFacade _mapFacade;

    public MapController(MapFacade mapFacade)
    {
        _mapFacade = mapFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<MapListModel>>))]
    public async Task<List<MapListModel>> GetAll()
    {
        return await _mapFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<MapDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<MapDetailModel?>> GetById(Guid id)
    { 
        var model = await _mapFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<MapDetailModel>))]
    public async Task<ActionResult<MapDetailModel>> CreateAsync(MapDetailModel model)
    {
        var id = await _mapFacade.CreateAsync(model);
        var detailModel = await _mapFacade.GetByIdAsync(id);
        return Created("Map/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<MapDetailModel>))]
    public async Task<ActionResult<MapDetailModel>> Update(MapDetailModel model)
    {
        var id = await _mapFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _mapFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _mapFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _mapFacade.DeleteAsync(id);
        return NoContent();
    }
}