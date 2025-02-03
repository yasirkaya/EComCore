namespace EComCore.Domain.DTOs.ReviewDTO
{
    public class CreateReviewDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
    }
}
