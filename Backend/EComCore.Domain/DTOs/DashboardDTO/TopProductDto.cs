namespace EComCore.Domain.DTOs.DashboardDTO;

public class TopProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int TotalSales { get; set; }
    public decimal TotalRevenue { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }
}