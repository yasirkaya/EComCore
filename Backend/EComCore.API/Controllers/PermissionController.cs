using EComCore.Application.PermissionOperations.Commands;
using EComCore.Application.PermissionOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PermissionController : BaseController
{
    private readonly IMediator _mediator;

    public PermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPermissions()
    {
        try
        {
            var permissions = await _mediator.Send(new GetPermissionsQuery());
            return Ok(permissions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermissionById(int id)
    {
        try
        {
            var permission = await _mediator.Send(new GetPermissionByIdQuery() { Id = id });
            return Ok(permission);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePermission(int id, [FromBody] UpdatePermissionCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePermission(int id)
    {
        try
        {
            await _mediator.Send(new DeletePermissionCommand() { Id = id });
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}