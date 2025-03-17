using EComCore.Domain.DTOs.DashboardDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.DashboardOperations.Queries;

public class GetRecentOrdersQueryHandler : IRequestHandler<GetRecentOrdersQuery, List<RecentOrderDto>>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public GetRecentOrdersQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<List<RecentOrderDto>> Handle(GetRecentOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.GetRecentOrdersAsync();
    }
}