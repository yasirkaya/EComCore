using EComCore.Application.CartOperations.Commands;
using EComCore.Application.CartOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EComCore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
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
    }
}