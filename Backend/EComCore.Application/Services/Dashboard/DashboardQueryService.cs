using EComCore.Domain.DTOs.DashboardDTO;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Application.Services.Dashboard;

public class DashboardQueryService : IDashboardQueryService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public DashboardQueryService(
        IUserRepository userRepository,
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<DashboardStatsDto> GetDashboardStatsAsync()
    {
        var stats = new DashboardStatsDto
        {
            TotalUsers = await _userRepository.GetTotalCountAsync(),
            TotalProducts = await _productRepository.GetTotalCountAsync(),
            TotalOrders = await _orderRepository.GetTotalCountAsync(),
            TotalRevenue = await _orderRepository.GetTotalRevenueAsync(),
            PendingOrders = await _orderRepository.GetPendingOrdersCountAsync(),
            LowStockProducts = await _productRepository.GetLowStockProductsCountAsync(),
            AverageOrderValue = await _orderRepository.GetAverageOrderValueAsync(),
            ConversionRate = await CalculateConversionRateAsync()
        };

        return stats;
    }

    public async Task<RevenueStatsDto> GetRevenueStatsAsync()
    {
        var today = DateTime.Today;
        var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
        var startOfMonth = new DateTime(today.Year, today.Month, 1);
        var startOfYear = new DateTime(today.Year, 1, 1);

        var stats = new RevenueStatsDto
        {
            DailyRevenue = await _orderRepository.GetRevenueByDateRangeAsync(today, today),
            WeeklyRevenue = await _orderRepository.GetRevenueByDateRangeAsync(startOfWeek, today),
            MonthlyRevenue = await _orderRepository.GetRevenueByDateRangeAsync(startOfMonth, today),
            YearlyRevenue = await _orderRepository.GetRevenueByDateRangeAsync(startOfYear, today),
            RevenueGrowth = await CalculateRevenueGrowthAsync(),
            RevenueByCategory = await GetRevenueByCategoryAsync()
        };

        return stats;
    }

    public async Task<List<TopProductDto>> GetTopProductsAsync()
    {
        // var topProducts = await _productRepository.GetTopSellingProductsAsync(10);
        // var orderItems = await _orderItemRepository.GetByProductIdAsync(topProducts.First().Id);

        // return topProducts.Select(p => new TopProductDto
        // {
        //     Id = p.Id,
        //     Name = p.Name,
        //     Price = p.Price,
        //     TotalSales = orderItems.Where(oi => oi.ProductId == p.Id).Sum(oi => oi.Quantity),
        //     TotalRevenue = orderItems.Where(oi => oi.ProductId == p.Id).Sum(oi => oi.TotalPrice),
        //     StockQuantity = p.StockQuantity,
        //     ImageUrl = p.ImageUrl
        // }).ToList();
        return new List<TopProductDto>();
    }

    public async Task<List<RecentOrderDto>> GetRecentOrdersAsync()
    {
        var recentOrders = await _orderRepository.GetRecentOrdersAsync(10);
        return recentOrders.Select(o => new RecentOrderDto
        {
            Id = o.Id,
            OrderNumber = o.Id.ToString(),
            CustomerName = o.User.Username,
            TotalAmount = o.TotalAmount,
            Status = o.OrderStatus.ToString(),
            OrderDate = o.CreatedAt,
            PaymentMethod = o.Payment?.PaymentMethod.ToString() ?? "N/A"
        }).ToList();
    }

    private async Task<decimal> CalculateConversionRateAsync()
    {
        var totalVisitors = await _userRepository.GetTotalVisitorsAsync();
        var totalOrders = await _orderRepository.GetTotalCountAsync();

        if (totalVisitors == 0) return 0;

        return (decimal)totalOrders / totalVisitors * 100;
    }

    private async Task<decimal> CalculateRevenueGrowthAsync()
    {
        var today = DateTime.Today;
        var lastMonth = today.AddMonths(-1);
        var lastYear = today.AddYears(-1);

        var currentMonthRevenue = await _orderRepository.GetRevenueByDateRangeAsync(
            new DateTime(today.Year, today.Month, 1), today);
        var lastMonthRevenue = await _orderRepository.GetRevenueByDateRangeAsync(
            new DateTime(lastMonth.Year, lastMonth.Month, 1), lastMonth);

        if (lastMonthRevenue == 0) return 0;

        return ((currentMonthRevenue - lastMonthRevenue) / lastMonthRevenue) * 100;
    }

    private async Task<List<RevenueByCategoryDto>> GetRevenueByCategoryAsync()
    {
        var revenueByCategory = await _orderItemRepository.GetRevenueByCategoryAsync();
        var totalRevenue = revenueByCategory.Sum(r => r.Revenue);

        return revenueByCategory.Select(r => new RevenueByCategoryDto
        {
            CategoryName = r.CategoryName,
            Revenue = r.Revenue,
            Percentage = totalRevenue > 0 ? (r.Revenue / totalRevenue) * 100 : 0
        }).ToList();
    }
}