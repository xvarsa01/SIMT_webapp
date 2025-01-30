using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<List<PlayerListModel>>))]
    public Task<List<PlayerListModel>> GetAll()
    {
        return _playerFacade.GetAllAsync();
    }
    
    [HttpGet("search")]
    [SwaggerResponse(200, typeof(ActionResult<IEnumerable<PlayerListModel>>))]
    [SwaggerResponse(204, null)]
    public async Task<ActionResult<IEnumerable<PlayerListModel>>> GetAllSearched(string searchTerm)
    {
        var results = await _playerFacade.GetAllAsync(searchTerm);
        if (!results.Any())
        {
            return NoContent();
        }
        return Ok(results);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlayerDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, typeof(ActionResult<PlayerDetailModel>))]
    public async Task<ActionResult<PlayerDetailModel?>> GetById(Guid id)
    { 
        var model = await _playerFacade.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpGet("nick")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlayerDetailModel>))]
    [SwaggerResponse(HttpStatusCode.NotFound, typeof(ActionResult<PlayerDetailModel>))]
    public async Task<ActionResult<PlayerDetailModel?>> GetByNick(string nick)
    { 
        var model = await _playerFacade.GetByNickAsync(nick);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }
    
    [HttpPost()]
    [SwaggerResponse(HttpStatusCode.Created, typeof(ActionResult<PlayerDetailModel>))]
    public async Task<ActionResult<PlayerDetailModel>> CreateAsync(PlayerDetailModel model)
    {
        var id = await _playerFacade.CreateAsync(model);
        var detailModel = await _playerFacade.GetByIdAsync(id);
        return Created("Player/{id}", detailModel);
    }

    [HttpPut]
    [SwaggerResponse(HttpStatusCode.OK, typeof(ActionResult<PlayerDetailModel>))]
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
    [SwaggerResponse(HttpStatusCode.NoContent, null)]
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