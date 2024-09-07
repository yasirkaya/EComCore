using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class GetCustomAttributeByIdQueryHandler : IRequestHandler<GetCustomAttributeByIdQuery, CustomAttributeDto>
{
    private readonly ICustomAttributeQueryService _queryService;
    public GetCustomAttributeByIdQueryHandler(ICustomAttributeQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<CustomAttributeDto> Handle(GetCustomAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetByIdAsync(request.Id);
    }
}