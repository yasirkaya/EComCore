namespace EComCore.Domain.DTOs.OrderDTO
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}