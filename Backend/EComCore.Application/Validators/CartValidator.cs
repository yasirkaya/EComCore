using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");

        RuleFor(x => x.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Toplam tutar 0'dan küçük olamaz");
    }
} 