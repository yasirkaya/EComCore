using EComCore.Domain.DTOs.DashboardDTO;

namespace EComCore.Domain.Services.Queries;

public interface IDashboardQueryService
{
    Task<DashboardStatsDto> GetDashboardStatsAsync();
    Task<RevenueStatsDto> GetRevenueStatsAsync();
    Task<List<TopProductDto>> GetTopProductsAsync();
    Task<List<RecentOrderDto>> GetRecentOrdersAsync();
}