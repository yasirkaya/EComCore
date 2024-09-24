using System.Security.Claims;
using EComCore.Application.UserOperations.Commands;
using EComCore.Application.UserOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("delete/{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteUserCommand { Id = id });
        return Ok();
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Get()
    {
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (userEmail == null)
        {
            return Unauthorized();
        }

        var result = await _mediator.Send(new GetCurrentUserQuery { Email = userEmail });

        return Ok(result);
    }

}