using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("Stop")]
public class StopController : ControllerBase
{
    private readonly StopFacade _stopFacade;

    public StopController(StopFacade stopFacade)
    {
        _stopFacade = stopFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<StopListModel>>))]
    public async Task<List<StopListModel>> GetAll()
    {
        return await _stopFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<StopDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<StopDetailModel?>> GetByIdAsync(Guid id)
    { 
        var model = await _stopFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpGet("Lines/{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<StopDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<List<LineListModel>?>> GetAllLinesForStopByIdAsync(Guid id)
    { 
        var models = await _stopFacade.GetAllLinesForStopByIdAsync(id);
        if (models == null)
        {
            return NotFound();
        }
        return Ok(models);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<StopDetailModel>))]
    public async Task<ActionResult<StopDetailModel>> CreateAsync(StopDetailModel model)
    {
        var id = await _stopFacade.CreateAsync(model);
        var detailModel = await _stopFacade.GetByIdAsync(id);
        return Created("Stop/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<StopDetailModel>))]
    public async Task<ActionResult<StopDetailModel>> Update(StopDetailModel model)
    {
        var id = await _stopFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _stopFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _stopFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _stopFacade.DeleteAsync(id);
        return NoContent();
    }
}