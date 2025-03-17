using EComCore.Domain.DTOs.DashboardDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.DashboardOperations.Queries;

public class GetTopProductsQueryHandler : IRequestHandler<GetTopProductsQuery, List<TopProductDto>>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public GetTopProductsQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<List<TopProductDto>> Handle(GetTopProductsQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.GetTopProductsAsync();
    }
}