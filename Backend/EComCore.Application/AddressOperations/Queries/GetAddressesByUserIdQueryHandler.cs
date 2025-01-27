using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressesByUserIdQueryHandler : IRequestHandler<GetAddressesByUserIdQuery, IEnumerable<AddressDto>>
{
    private readonly IAddressQueryService _addressQueryService;
    private readonly IMapper _mapper;
    public GetAddressesByUserIdQueryHandler(IAddressQueryService addressQueryService, IMapper mapper)
    {
        _addressQueryService = addressQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> Handle(GetAddressesByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await _addressQueryService.GetByUserIdAsync(request.UserId);
    }
}