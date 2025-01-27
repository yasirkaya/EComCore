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
            var result = await _mediator.Send(new GetAddressesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAddressByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var result = await _mediator.Send(new GetAddressByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateAddressCommand command)
        {
            command.UserId = GetCurrentUserId();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAddressCommand { Id = id });
            return Ok();
        }
    }
}