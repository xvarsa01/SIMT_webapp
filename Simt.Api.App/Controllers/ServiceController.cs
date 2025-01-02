using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    private readonly ServiceFacade _serviceFacade;

    public ServiceController(ServiceFacade serviceFacade)
    {
        _serviceFacade = serviceFacade;
    }

    [HttpGet("all")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<ServiceListModel>>))]
    public async Task<List<ServiceListModel>> GetAll()
    {
        return await _serviceFacade.GetAllAsync();
    }
    
    [HttpGet("active")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<ServiceDetailModel>>))]
    public async Task<List<ServiceDetailModel>> GetAllActiveAsync()
    { 
        return await _serviceFacade.GetAllActiveAsync();
    }
    
    [HttpGet("player")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<ServiceDetailModel>>))]
    public async Task<List<ServiceDetailModel>> GetAllForPlayerAsync(Guid id, int pageNumber, int pageSize)
    { 
        return await _serviceFacade.GetAllForPlayerAsync(id, pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<ServiceDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, null)]
    public async Task<ActionResult<ServiceDetailModel?>> GetById(Guid id)
    { 
        var model = await _serviceFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<ServiceDetailModel>))]
    public async Task<ActionResult<ServiceDetailModel>> CreateAsync(ServiceDetailModel model)
    {
        var id = await _serviceFacade.CreateAsync(model);
        var detailModel = await _serviceFacade.GetByIdAsync(id);
        return Created("Service/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<ServiceDetailModel>))]
    public async Task<ActionResult<ServiceDetailModel>> Update(ServiceDetailModel model)
    {
        var id = await _serviceFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _serviceFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _serviceFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _serviceFacade.DeleteAsync(id);
        return NoContent();
    }
}