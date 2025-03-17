namespace EComCore.Domain.DTOs.DashboardDTO;

public class RecentOrderDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public DateTime OrderDate { get; set; }
    public string PaymentMethod { get; set; }
}