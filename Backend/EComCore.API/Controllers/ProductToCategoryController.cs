using EComCore.Application.ProductToCategoryOperations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductToCategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductToCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductToCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProductToCategoryCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductToCategoryCommand { Id = id });
        return Ok();
    }

    [HttpDelete("products/{productId}/categories")]
    public async Task<IActionResult> DeleteByProductId(int productId)
    {
        await _mediator.Send(new DeleteProductFromCategoriesCommand { ProductId = productId });
        return Ok();
    }
}