using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AddressOperations.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressCommandService _addressCommandService;
        private readonly IMapper _mapper;
        public CreateAddressCommandHandler(IAddressCommandService addressCommandService, IMapper mapper)
        {
            _addressCommandService = addressCommandService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressCommandService.CreateAddressAsync(_mapper.Map<CreateAddressDto>(request));
        }
    }
}