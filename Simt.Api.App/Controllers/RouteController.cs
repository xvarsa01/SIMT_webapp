using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("route")]
public class RouteController : ControllerBase
{
    private readonly RouteFacade _routeFacade;

    public RouteController(RouteFacade routeFacade)
    {
        _routeFacade = routeFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<RouteListModel>>))]
    public async Task<List<RouteListModel>> GetAll()
    {
        return await _routeFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<RouteDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<RouteDetailModel?>> GetById(Guid id)
    { 
        var model = await _routeFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<RouteDetailModel>))]
    public async Task<ActionResult<RouteDetailModel>> CreateAsync(RouteCreationModel model)
    {
        var id = await _routeFacade.CreateAsync(model);
        var detailModel = await _routeFacade.GetByIdAsync(id);
        return Created("route/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<RouteDetailModel>))]
    public async Task<ActionResult<RouteDetailModel>> Update(RouteCreationModel model)
    {
        var id = await _routeFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _routeFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _routeFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _routeFacade.DeleteAsync(id);
        return NoContent();
    }
}