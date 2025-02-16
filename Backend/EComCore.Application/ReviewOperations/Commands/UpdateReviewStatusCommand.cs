using EComCore.Domain.Enums;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands
{
    public class UpdateReviewStatusCommand : IRequest<bool>
    {
        public int Id { get; set; } // Güncellenecek yorumun ID'si
        public ReviewStatus Status { get; set; } // Yeni durum (örneğin, "Onaylandı", "Reddedildi")
        public string ModerationReason { get; set; } // Moderasyon sebebi (isteğe bağlı)
    }
}