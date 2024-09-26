using EComCore.Application.ProductToAttributeOperations.Commands.Queries;
using EComCore.Application.ProductToCategoryOperations.Commands;
using EComCore.Application.ProductToCategoryOperations.Queries;
using EComCore.Domain.Shared.RequestFeatures;
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
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetProductToCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("products/{productId}/categories")]
    public async Task<IActionResult> GetCategoriesByProductId(int productId)
    {
        var result = await _mediator.Send(new GetCategoriesByProductIdQuery { ProductId = productId });
        return Ok(result);
    }

    [HttpGet("categories/{categoryId}/products")]
    public async Task<IActionResult> GetProductsByCategoryId(int categoryId, [FromQuery] ProductToCategoryParameters productToCategoryParameters)
    {
        var result = await _mediator.Send(new GetProductsByCategoryIdQuery(productToCategoryParameters) { CategoryId = categoryId });
        return Ok(result);
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