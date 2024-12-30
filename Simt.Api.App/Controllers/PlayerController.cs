using System.Net;
using Microsoft.AspNetCore.Mvc;
using Simt.Api.BL.Facades;
using Simt.Common.Models;

namespace Simt.Api.App.Controllers;

[ApiController]
[Route("player")]
public class PlayerController : ControllerBase
{
    private readonly PlayerFacade _playerFacade;

    public PlayerController(PlayerFacade playerFacade)
    {
        _playerFacade = playerFacade;
    }

    [HttpGet("all")]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<PlayerModel>>))]
    public Task<List<PlayerListModel>> GetAll()
    {
        return _playerFacade.GetAllAsync();
    }

    [HttpGet("{id}")]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlayerModel>))]
    // [SwaggerResponse(HttpStatusCode.NotFound, typeof(ActionResult<PlayerModel>))]
    public async Task<ActionResult<PlayerDetailModel?>> GetById(Guid id)
    { 
        var model = await _playerFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    // [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<PlayerModel>))]
    public async Task<ActionResult<PlayerDetailModel>> CreateAsync(PlayerDetailModel model)
    {
        var id = await _playerFacade.CreateAsync(model);
        var detailModel = await _playerFacade.GetByIdAsync(id);
        return Created("Player/{id}", detailModel);
    }

    [HttpPut]
    // [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlayerModel>))]
    public async Task<ActionResult<PlayerDetailModel>> Update(PlayerDetailModel model)
    {
        var id = await _playerFacade.UpdateAsync(model);
        if (id != null)
        {
            var detailModel = await _playerFacade.GetByIdAsync((Guid)id);
            return Ok(detailModel);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    // [SwaggerResponse(HttpStatusCode.NoContent, null)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var detailModel = await _playerFacade.GetByIdAsync(id);
        if (detailModel is null)
        {
            return NotFound($"Entity with id {id} not found.");
        }
        await _playerFacade.DeleteAsync(id);
        return NoContent();
    }
}