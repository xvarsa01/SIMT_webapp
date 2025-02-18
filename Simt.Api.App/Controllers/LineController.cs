using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("Line")]
public class LineController : ControllerBase
{
    private readonly LineFacade _lineFacade;

    public LineController(LineFacade lineFacade)
    {
        _lineFacade = lineFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<LineListModel>>))]
    public async Task<List<LineListModel>> GetAll()
    {
        return await _lineFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<LineDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<LineDetailModel?>> GetById(Guid id)
    { 
        var model = await _lineFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<LineDetailModel>))]
    public async Task<ActionResult<LineDetailModel>> CreateAsync(LineCreationModel model)
    {
        var id = await _lineFacade.CreateAsync(model);
        var detailModel = await _lineFacade.GetByIdAsync(id);
        return Created("Line/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<LineDetailModel>))]
    public async Task<ActionResult<LineDetailModel>> Update(LineCreationModel model)
    {
        var id = await _lineFacade.UpdateAsync(model);
        if (id != null)
        {
            LineDetailModel? detailModel = await _lineFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _lineFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _lineFacade.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpGet("map/{mapId}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<LineListModel>>))]
    public async Task<List<LineListModel>> GetAllByMapAsync(Guid mapId)
    {
        return await _lineFacade.GetAllByMapAsync(mapId);
    }
}