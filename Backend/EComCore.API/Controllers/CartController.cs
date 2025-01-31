using EComCore.Application.CartOperations.Commands;
using EComCore.Application.CartOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : BaseController
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var query = new GetCartQuery { UserId = GetCurrentUserId() };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("items")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartCommand command)
    {
        command.UserId = GetCurrentUserId();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("items")]
    public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemCommand command)
    {
        command.UserId = GetCurrentUserId();
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("items/{productId}")]
    public async Task<IActionResult> RemoveFromCart(int productId)
    {
        var command = new RemoveFromCartCommand { UserId = GetCurrentUserId(), ProductId = productId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("clear")]
    public async Task<IActionResult> ClearCart()
    {
        var command = new ClearCartCommand { UserId = GetCurrentUserId() };
        await _mediator.Send(command);
        return Ok();
    }
}