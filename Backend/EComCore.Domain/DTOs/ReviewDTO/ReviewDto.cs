using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.ReviewDTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public ReviewStatus Status { get; set; }
        public string ModerationReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
