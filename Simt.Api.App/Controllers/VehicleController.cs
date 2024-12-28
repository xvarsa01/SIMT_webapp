using System.Net;
using Microsoft.AspNetCore.Mvc;
using Simt.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("vehicle")]
public class VehicleController : ControllerBase
{
    private readonly VehicleFacade _vehicleFacade;

    public VehicleController(VehicleFacade vehicleFacade)
    {
        _vehicleFacade = vehicleFacade;
    }

    [HttpGet("all")]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<vehicleModel>>))]
    public Task<List<VehicleListModel>> GetAll()
    {
        return _vehicleFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<vehicleModel>))]
    // [SwaggerResponse(HttpStatusCode.NotFound, typeof(ActionResult<vehicleModel>))]
    public async Task<ActionResult<VehicleDetailModel?>> GetById(Guid id)
    { 
        var model = await _vehicleFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    // [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<vehicleModel>))]
    public async Task<ActionResult<VehicleDetailModel>> CreateAsync(VehicleDetailModel model)
    {
        var id = await _vehicleFacade.CreateAsync(model);
        var detailModel = await _vehicleFacade.GetByIdAsync(id);
        return Created("vehicle/{id}", detailModel);
    }

    [HttpPut]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<vehicleModel>))]
    public async Task<ActionResult<VehicleDetailModel>> Update(VehicleDetailModel model)
    {
        var id = await _vehicleFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _vehicleFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    // [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _vehicleFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _vehicleFacade.DeleteAsync(id);
        return NoContent();
    }
}