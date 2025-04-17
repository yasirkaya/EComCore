using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ProductToCategoryValidator : AbstractValidator<ProductToCategory>
{
    public ProductToCategoryValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Ürün ID boş olamaz");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Kategori ID boş olamaz");
    }
} 