using System.Threading.Tasks;
using EComCore.Application.OrderOperations.Commands;
using EComCore.Application.OrderOperations.Queries;
using EComCore.Domain.DTOs.OrderDTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var command = new CreateOrderCommand(createOrderDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus([FromBody] UpdateOrderStatusDto updateOrderStatusDto)
        {
            var command = new UpdateOrderStatusCommand(updateOrderStatusDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> CancelOrder(int id)
        {
            var command = new CancelOrderCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}