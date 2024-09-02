using EComCore.Domain.DTOs.AttributeDto;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributesQueryHandler : IRequestHandler<GetCustomAttributesQuery, IEnumerable<CustomAttributeDto>>
{
    private readonly ICustomAttributeQueryService _queryService;
    public GetCustomAttributesQueryHandler(ICustomAttributeQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IEnumerable<CustomAttributeDto>> Handle(GetCustomAttributesQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetAllAsync();
    }
}