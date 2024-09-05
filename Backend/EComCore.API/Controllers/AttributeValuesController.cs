using EComCore.Application.AttributeValueOperations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AttributeValuesController : ControllerBase
{
    private readonly IMediator _mediator;
    public AttributeValuesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAttributeValueCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAttributeValueCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteAttributeValueCommand { Id = id });
        return Ok();
    }

    [HttpDelete("attribute/{attributeId}/values")]
    public async Task<IActionResult> DeleteRange(int attributeId)
    {
        await _mediator.Send(new DeleteByAttributeIdCommand { AttributeId = attributeId });
        return Ok();

    }
}