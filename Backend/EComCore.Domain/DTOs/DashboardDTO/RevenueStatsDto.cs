namespace EComCore.Domain.DTOs.DashboardDTO;

public class RevenueStatsDto
{
    public decimal DailyRevenue { get; set; }
    public decimal WeeklyRevenue { get; set; }
    public decimal MonthlyRevenue { get; set; }
    public decimal YearlyRevenue { get; set; }
    public decimal RevenueGrowth { get; set; }
    public List<RevenueByCategoryDto> RevenueByCategory { get; set; }
}

public class RevenueByCategoryDto
{
    public string CategoryName { get; set; }
    public decimal Revenue { get; set; }
    public decimal Percentage { get; set; }
}