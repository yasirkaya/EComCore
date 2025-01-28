using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using EComCore.Application.AddressOperations.Queries;
using EComCore.Application.AddressOperations.Commands;


namespace EComCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IMediator _mediator;


        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var result = await _mediator.Send(new GetAddressesQuery());
                return Ok(new { data = result, message = "Addresses retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Addresses not found.", message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAddressByIdQuery { Id = id });
                return Ok(new { data = result, message = "Address retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Address not found.", message = ex.Message });
            }

        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetAddressesByUserIdQuery { UserId = userId });
                return Ok(new { data = result, message = "Addresses retrieved successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "User not found.", message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateAddressCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok(new { message = "Address created successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "User not found.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateAddressCommand command, int id)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return Ok(new { message = "Address updated successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Address not found.", message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteAddressCommand { Id = id });
                return Ok(new { message = "Address deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { error = "Address not found.", message = ex.Message });
            }
        }
    }
}