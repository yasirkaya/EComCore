using EComCore.Application.OrderOperations.Commands;
using EComCore.Application.OrderOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : BaseController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        command.CreateOrderDto.UserId = GetCurrentUserId();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var query = new GetOrdersQuery { UserId = GetCurrentUserId() };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}