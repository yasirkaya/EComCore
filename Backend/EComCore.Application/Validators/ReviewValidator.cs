using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ReviewValidator : AbstractValidator<Review>
{
    public ReviewValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Ürün ID boş olamaz");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Değerlendirme 1-5 arasında olmalıdır");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Yorum boş olamaz")
            .MaximumLength(1000).WithMessage("Yorum en fazla 1000 karakter olabilir");
    }
} 