using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.ReviewDTO
{
    public class UpdateStatusDto
    {
        public int Id { get; set; }
        public ReviewStatus Status { get; set; }
        public string ModerationReason { get; set; }
    }
}