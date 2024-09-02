using EComCore.Application.CustomAttributeOperations.Commands;
using EComCore.Application.CustomAttributeOperations.Queries;
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

    [HttpGet]
    public async Task<IActionResult> GetCustomAttribute()
    {
        var result = await _mediator.Send(new GetCustomAttributesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomAttributeById(int id)
    {
        var result = await _mediator.Send(new GetCustomAttributeByIdQuery { Id = id });
        return Ok(result);
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