using EComCore.Application.RolePermissionOperations.Commands;
using EComCore.Application.RolePermissionOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolePermissionController : BaseController
{
    private readonly IMediator _mediator;

    public RolePermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRolePermissions()
    {
        try
        {
            var rolePermissions = await _mediator.Send(new GetRolePermissionsQuery());
            return Ok(rolePermissions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRolePermissionById(int id)
    {
        try
        {
            var rolePermission = await _mediator.Send(new GetRolePermissionByIdQuery() { Id = id });
            return Ok(rolePermission);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRolePermission([FromBody] CreateRolePermissionCommand command)
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
    public async Task<IActionResult> UpdateRolePermission(int id, [FromBody] UpdateRolePermissionCommand command)
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
    public async Task<IActionResult> DeleteRolePermission(int id)
    {
        try
        {
            await _mediator.Send(new DeleteRolePermissionCommand() { Id = id });
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}