using System.Security.Claims;
using EComCore.Application.AuthOperations.Commands;
using EComCore.Domain.DTOs.AuthDTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {

        var result = await _mediator.Send(command);
        return Ok(result);

    }

    [Authorize]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);

    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (userEmail == null)
        {
            return BadRequest("Email address not found. Please log in.");
        }

        await _mediator.Send(new LogoutUserCommand { Email = userEmail });

        return Ok(new { message = "Logout successful." });
    }

}