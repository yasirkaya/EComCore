using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AddressOperations.Commands;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IAddressCommandService _addressService;
    private readonly IMapper _mapper;
    public DeleteAddressCommandHandler(IAddressCommandService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressService.DeleteAddressAsync(_mapper.Map<DeleteAddressDto>(request));
        return;
    }
}