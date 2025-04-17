using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Sipariş ID boş olamaz");

        RuleFor(x => x.ProductVariantId)
            .NotEmpty().WithMessage("Ürün varyantı ID boş olamaz");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalıdır");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("Toplam fiyat 0'dan büyük olmalıdır");
    }
} 