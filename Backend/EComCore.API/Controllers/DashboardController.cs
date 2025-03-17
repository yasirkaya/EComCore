using EComCore.Application.DashboardOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : BaseController
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("stats")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetDashboardStats()
    {
        var result = await _mediator.Send(new GetDashboardStatsQuery());
        return Ok(result);
    }

    [HttpGet("revenue")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRevenueStats()
    {
        var result = await _mediator.Send(new GetRevenueStatsQuery());
        return Ok(result);
    }

    [HttpGet("top-products")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTopProducts()
    {
        var result = await _mediator.Send(new GetTopProductsQuery());
        return Ok(result);
    }

    [HttpGet("recent-orders")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRecentOrders()
    {
        var result = await _mediator.Send(new GetRecentOrdersQuery());
        return Ok(result);
    }
}