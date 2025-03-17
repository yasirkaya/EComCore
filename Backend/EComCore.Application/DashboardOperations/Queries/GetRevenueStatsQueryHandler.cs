using EComCore.Domain.DTOs.DashboardDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.DashboardOperations.Queries;

public class GetRevenueStatsQueryHandler : IRequestHandler<GetRevenueStatsQuery, RevenueStatsDto>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public GetRevenueStatsQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<RevenueStatsDto> Handle(GetRevenueStatsQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.GetRevenueStatsAsync();
    }
}