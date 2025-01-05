using EComCore.Application.CustomAttributeOperations.Commands;
using EComCore.Application.CustomAttributeOperations.Queries;
using EComCore.Application.AttributeValueOperations.Commands;
using EComCore.Application.AttributeValueOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/product-specifications")]
public class ProductSpecificationsController : BaseController
{
    private readonly IMediator _mediator;

    public ProductSpecificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Specification Groups
    [HttpGet("groups")]
    public async Task<IActionResult> GetSpecificationGroups()
    {
        var result = await _mediator.Send(new GetCustomAttributesQuery());
        return Ok(result);
    }

    [HttpGet("groups/{id}")]
    public async Task<IActionResult> GetSpecificationGroupById(int id)
    {
        var result = await _mediator.Send(new GetCustomAttributeByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost("groups")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateSpecificationGroup([FromBody] CreateCustomAttributeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("groups/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateSpecificationGroup(int id, [FromBody] UpdateCustomAttributeCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("groups/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSpecificationGroup(int id)
    {
        await _mediator.Send(new DeleteCustomAttributeCommand { Id = id });
        return Ok();
    }
    #endregion

    #region Specification Values
    [HttpGet("values")]
    public async Task<IActionResult> GetSpecificationValues()
    {
        var result = await _mediator.Send(new GetAttributeValuesQuery());
        return Ok(result);
    }

    [HttpGet("values/{id}")]
    public async Task<IActionResult> GetSpecificationValueById(int id)
    {
        var result = await _mediator.Send(new GetAttributeValueByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpGet("groups/{groupId}/values")]
    public async Task<IActionResult> GetSpecificationValuesByGroupId(int groupId)
    {
        var result = await _mediator.Send(new GetValuesByAttributeIdQuery { AttributeId = groupId });
        return Ok(result);
    }

    [HttpPost("values")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateSpecificationValue([FromBody] CreateAttributeValueCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("values/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateSpecificationValue(int id, [FromBody] UpdateAttributeValueCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("values/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSpecificationValue(int id)
    {
        await _mediator.Send(new DeleteAttributeValueCommand { Id = id });
        return Ok();
    }

    [HttpDelete("groups/{groupId}/values")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSpecificationValuesByGroupId(int groupId)
    {
        await _mediator.Send(new DeleteByAttributeIdCommand { AttributeId = groupId });
        return Ok();
    }
    #endregion
}