using EComCore.Application.AttributeValueOperations.Commands;
using EComCore.Application.AttributeValueOperations.Queries;
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAttributeValuesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetAttributeValueByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpGet("attributes/{attributeId}/values")]
    public async Task<IActionResult> GetValuesByAttributeId(int attributeId)
    {
        var result = await _mediator.Send(new GetValuesByAttributeIdQuery { AttributeId = attributeId });
        return Ok(result);
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