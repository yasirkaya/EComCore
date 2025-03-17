using EComCore.Domain.DTOs.DashboardDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.DashboardOperations.Queries;

public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, DashboardStatsDto>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public GetDashboardStatsQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<DashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.GetDashboardStatsAsync();
    }
}