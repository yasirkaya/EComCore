using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Queries;

public class GetAttributeValueByIdQueryHandler : IRequestHandler<GetAttributeValueByIdQuery, AttributeValueDto>
{
    private readonly IAttributeValueQueryService _queryService;
    public GetAttributeValueByIdQueryHandler(IAttributeValueQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<AttributeValueDto> Handle(GetAttributeValueByIdQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetAttributeValueByIdAsync(request.Id);
    }
}