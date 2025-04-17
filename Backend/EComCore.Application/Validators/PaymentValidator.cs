using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class PaymentValidator : AbstractValidator<Payment>
{
    public PaymentValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Sipariş ID boş olamaz");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Ödeme tutarı 0'dan büyük olmalıdır");

        RuleFor(x => x.PaymentMethod)
            .IsInEnum().WithMessage("Geçersiz ödeme yöntemi");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Geçersiz ödeme durumu");

        RuleFor(x => x.FailureReason)
            .MaximumLength(500).WithMessage("Hata nedeni en fazla 500 karakter olabilir");
    }
} 