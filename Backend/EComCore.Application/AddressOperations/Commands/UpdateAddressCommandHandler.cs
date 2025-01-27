using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AddressOperations.Commands;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IAddressCommandService _addressService;
    private readonly IMapper _mapper;
    public UpdateAddressCommandHandler(IAddressCommandService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressService.UpdateAddressAsync(_mapper.Map<UpdateAddressDto>(request));
        return;
    }
}