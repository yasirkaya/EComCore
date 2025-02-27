using EComCore.Application.RoleOperations.Commands;
using EComCore.Application.RoleOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRoles()
    {
        try
        {
            var result = await _mediator.Send(new GetRolesQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { error = "Roles not found.", message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetRoleByIdQuery { Id = id });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { error = "Role not found.", message = ex.Message });
        }
    }

    [HttpGet("byname/{name}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var result = await _mediator.Send(new GetRoleByNameQuery { Name = name });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { error = "Role not found.", message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] CreateRoleCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok(new { message = "Role successfully added." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "Role not added.", message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateRoleCommand command)
    {
        command.Id = id;
        try
        {
            await _mediator.Send(command);
            return Ok(new { message = "Role successfully updated." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "Role not updated.", message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _mediator.Send(new DeleteRoleCommand { Id = id });
            return Ok(new { message = "Role successfully deleted." });
        }
        catch (Exception ex)
        {
            return NotFound(new { error = "Role not found.", message = ex.Message });
        }
    }



}