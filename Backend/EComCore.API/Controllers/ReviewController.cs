using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using EComCore.Application.ReviewOperations.Queries;
using EComCore.Application.ReviewOperations.Commands;
using EComCore.Domain.Entities;

namespace EComCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseController
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var result = await _mediator.Send(new GetReviewsQuery());
                return Ok(new { data = result, message = "Reviews retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Reviews not found.", message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetReviewByIdQuery { Id = id });
                return Ok(new { data = result, message = "Review retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Review not found.", message = ex.Message });
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            try
            {
                var result = await _mediator.Send(new GetReviewsByProductIdQuery { ProductId = productId });
                return Ok(new { data = result, message = "Reviews retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Product not found.", message = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetReviewsByUserIdQuery { UserId = userId });
                return Ok(new { data = result, message = "Reviews retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "User not found.", message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateReviewCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new { data = result, message = "Review created successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "User or Product not found.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateReviewCommand command, int id)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return Ok(new { message = "Review updated successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Review not found.", message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteReviewCommand { Id = id });
                return Ok(new { message = "Review deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Review not found.", message = ex.Message });
            }
        }
    }
}
