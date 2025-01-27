using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
{
    private readonly IAddressQueryService _addressQueryService;
    private readonly IMapper _mapper;
    public GetAddressByIdQueryHandler(IAddressQueryService addressQueryService, IMapper mapper)
    {
        _addressQueryService = addressQueryService;
        _mapper = mapper;
    }

    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        return await _addressQueryService.GetByIdAsync(request.Id);
    }
}