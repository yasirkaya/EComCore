using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetValuesByAttributeIdQueryHandler : IRequestHandler<GetValuesByAttributeIdQuery, IEnumerable<AttributeValueDto>>
{
    private readonly IAttributeValueQueryService _queryService;
    public GetValuesByAttributeIdQueryHandler(IAttributeValueQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IEnumerable<AttributeValueDto>> Handle(GetValuesByAttributeIdQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetValuesByAttributeIdAsync(request.AttributeId);
    }
}
