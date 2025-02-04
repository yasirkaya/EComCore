namespace EComCore.Domain.DTOs.ReviewDTO
{
    public class UpdateReviewDto
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string? Status { get; set; }
        public string? ModerationReason { get; set; }
    }
}
