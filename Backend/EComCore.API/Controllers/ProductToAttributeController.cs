using EComCore.Application.ProductToAttributeOperations.Commands;
using EComCore.Application.ProductToAttributeOperations.Commands.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductToAttributeController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductToAttributeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProductToAttributesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductToAttributeByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] CreateProductToAttributeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("attributes")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAttributesToProduct([FromBody] AddAttributesToProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("id")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProductToAttributeCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("id")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductToAttributeCommand { Id = id });
        return Ok();
    }

    [HttpDelete("products/{productId}/attributes")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAttributesByProductId(int productId)
    {
        await _mediator.Send(new DeleteAttributesByProductIdCommand { ProductId = productId });
        return Ok();
    }
}