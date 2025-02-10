using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.ReviewDTO
{
    public class UpdateReviewDto
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public ReviewStatus? Status { get; set; }
        public string? ModerationReason { get; set; }
    }
}
