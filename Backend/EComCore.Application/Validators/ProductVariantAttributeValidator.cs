using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ProductVariantAttributeValidator : AbstractValidator<ProductVariantAttribute>
{
    public ProductVariantAttributeValidator()
    {
        RuleFor(x => x.ProductVariantId)
            .NotEmpty().WithMessage("Ürün varyantı ID boş olamaz");

        RuleFor(x => x.AttributeId)
            .NotEmpty().WithMessage("Özellik ID boş olamaz");

        RuleFor(x => x.AttributeValueId)
            .NotEmpty().WithMessage("Özellik değeri ID boş olamaz");
    }
} 