using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("Platform")]
public class PlatformController : ControllerBase
{
    private readonly PlatformFacade _platformFacade;

    public PlatformController(PlatformFacade platformFacade)
    {
        _platformFacade = platformFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<PlatformDetailModel>>))]
    public async Task<List<PlatformListModel>> GetAll()
    {
        return await _platformFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlatformDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<PlatformDetailModel?>> GetById(Guid id)
    { 
        var model = await _platformFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<PlatformDetailModel>))]
    public async Task<ActionResult<PlatformDetailModel>> CreateAsync(PlatformCreationModel model)
    {
        var id = await _platformFacade.CreateAsync(model);
        var detailModel = await _platformFacade.GetByIdAsync(id);
        return Created("Platform/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlatformDetailModel>))]
    public async Task<ActionResult<PlatformDetailModel>> Update(PlatformCreationModel model)
    {
        var id = await _platformFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _platformFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _platformFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _platformFacade.DeleteAsync(id);
        return NoContent();
    }
}