using EComCore.Application.CustomAttributeOperations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomAttributeController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomAttributeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomAttribute(CreateCustomAttributeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomAttribute(int id, [FromBody] UpdateCustomAttributeCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomAttribute(int id)
    {
        await _mediator.Send(new DeleteCustomAttributeCommand { Id = id });
        return Ok();
    }
}