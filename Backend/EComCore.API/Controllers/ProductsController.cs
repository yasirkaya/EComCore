using EComCore.Application.ProductOperations.Commands;
using EComCore.Application.ProductOperations.Queries;
using EComCore.Application.ProductToAttributeOperations.Commands;
using EComCore.Application.ProductToAttributeOperations.Commands.Queries;
using EComCore.Application.ProductToCategoryOperations.Commands;
using EComCore.Application.ProductToCategoryOperations.Queries;
using EComCore.Domain.Shared.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Product Operations
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
    {
        var result = await _mediator.Send(new GetProductsQuery(productParameters));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand { Id = id });
        return Ok();
    }

    [HttpPost("{id}/images")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UploadProductImage(int id, IFormFile image)
    {
        var command = new UploadProductImageCommand { ProductId = id, Image = image };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    #endregion

    #region Product Category Operations
    [HttpGet("{productId}/categories")]
    public async Task<IActionResult> GetProductCategories(int productId)
    {
        var result = await _mediator.Send(new GetCategoriesByProductIdQuery { ProductId = productId });
        return Ok(result);
    }

    [HttpPost("{productId}/categories")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddProductToCategory(int productId, [FromBody] CreateProductToCategoryCommand command)
    {
        command.ProductId = productId;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{productId}/categories/{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveProductFromCategory(int productId, int categoryId)
    {
        await _mediator.Send(new DeleteProductFromCategoriesCommand { ProductId = productId });
        return Ok();
    }
    #endregion

    #region Product Attribute Operations
    [HttpGet("{productId}/attributes")]
    public async Task<IActionResult> GetProductAttributes(int productId)
    {
        var result = await _mediator.Send(new GetProductToAttributeByIdQuery { Id = productId });
        return Ok(result);
    }

    [HttpPost("{productId}/attributes")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAttributesToProduct([FromBody] AddAttributesToProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{productId}/attributes/{attributeId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProductAttribute(int productId, int attributeId, [FromBody] UpdateProductToAttributeCommand command)
    {
        command.ProductId = productId;
        command.AttributeId = attributeId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{productId}/attributes")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveProductAttributes(int productId)
    {
        await _mediator.Send(new DeleteAttributesByProductIdCommand { ProductId = productId });
        return Ok();
    }
    #endregion
}