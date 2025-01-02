using System.Security.Claims;
using System.Threading.Tasks;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComCore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartCommandService _cartCommandService;
        private readonly ICartQueryService _cartQueryService;

        public CartController(ICartCommandService cartCommandService, ICartQueryService cartQueryService)
        {
            _cartCommandService = cartCommandService;
            _cartQueryService = cartQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = await _cartQueryService.GetCartAsync(userId);

            if (cart == null)
                return NotFound("Active cart not found");

            return Ok(cart);
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _cartCommandService.AddToCartAsync(userId, request.ProductId, request.Quantity);

            if (!result)
                return BadRequest("Failed to add item to cart");

            return Ok("Item added to cart successfully");
        }

        [HttpPut("items")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _cartCommandService.UpdateCartItemAsync(userId, request.ProductId, request.Quantity);

            if (!result)
                return BadRequest("Failed to update cart item");

            return Ok("Cart item updated successfully");
        }

        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _cartCommandService.RemoveFromCartAsync(userId, productId);

            if (!result)
                return BadRequest("Failed to remove item from cart");

            return Ok("Item removed from cart successfully");
        }
    }
}