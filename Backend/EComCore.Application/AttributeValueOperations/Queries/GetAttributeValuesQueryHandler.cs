using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetAttributeValuesQueryHandler : IRequestHandler<GetAttributeValuesQuery, IEnumerable<AttributeValueDto>>
{
    private readonly IAttributeValueQueryService _queryService;
    public GetAttributeValuesQueryHandler(IAttributeValueQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IEnumerable<AttributeValueDto>> Handle(GetAttributeValuesQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetAllAsync();
    }
}