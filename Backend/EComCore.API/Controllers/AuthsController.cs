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
}