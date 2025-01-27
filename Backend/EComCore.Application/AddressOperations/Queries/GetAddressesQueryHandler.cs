using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IEnumerable<AddressDto>>
{
    private readonly IAddressQueryService _addressQueryService;
    private readonly IMapper _mapper;
    public GetAddressesQueryHandler(IAddressQueryService addressQueryService, IMapper mapper)
    {
        _addressQueryService = addressQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
    {
        return await _addressQueryService.GetAllAsync();
    }
}