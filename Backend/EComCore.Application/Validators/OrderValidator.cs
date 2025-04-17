using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");

        RuleFor(x => x.TotalAmount)
            .GreaterThan(0).WithMessage("Toplam tutar 0'dan büyük olmalıdır");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Geçersiz sipariş durumu");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Teslimat adresi boş olamaz")
            .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir");

        RuleFor(x => x.BillingAddress)
            .NotEmpty().WithMessage("Fatura adresi boş olamaz")
            .MaximumLength(500).WithMessage("Fatura adresi en fazla 500 karakter olabilir");
    }
} 