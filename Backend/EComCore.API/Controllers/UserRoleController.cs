using EComCore.Application.Features.UserRoles.Queries;
using EComCore.Application.UserRoleOperations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserRoleController : BaseController
{
    private readonly IMediator _mediator;

    public UserRoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserRoles()
    {
        try
        {
            var userRoles = await _mediator.Send(new GetUserRolesQuery());
            return Ok(userRoles);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserRoleById(int id)
    {
        try
        {
            var userRole = await _mediator.Send(new GetUserRoleByIdQuery() { Id = id });
            return Ok(userRole);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserRoleByUserId(int userId)
    {
        try
        {
            var userRoles = await _mediator.Send(new GetUserRoleByUserIdQuery() { UserId = userId });
            return Ok(userRoles);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("role/{roleId}")]
    public async Task<IActionResult> GetUserRoleByRoleId(int roleId)
    {
        try
        {
            var users = await _mediator.Send(new GetUserRoleByRoleIdQuery() { RoleId = roleId });
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserRole([FromBody] CreateUserRoleCommand command)
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
    public async Task<IActionResult> UpdateUserRole(int id, [FromBody] UpdateUserRoleCommand command)
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
    public async Task<IActionResult> DeleteUserRole(int id)
    {
        try
        {
            await _mediator.Send(new DeleteUserRoleCommand() { Id = id });
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("user/{userId}/role/{roleId}")]
    public async Task<IActionResult> DeleteUserRoleByUserIdAndRoleId(int userId, int roleId)
    {
        try
        {
            await _mediator.Send(new DeleteUserRoleByUserIdAndRoleIdCommand() { UserId = userId, RoleId = roleId });
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}