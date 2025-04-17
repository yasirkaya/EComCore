using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ProductVariantValidator : AbstractValidator<ProductVariant>
{
    public ProductVariantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Varyant adı boş olamaz")
            .MaximumLength(255).WithMessage("Varyant adı en fazla 255 karakter olabilir");

        RuleFor(x => x.SKU)
            .NotEmpty().WithMessage("SKU boş olamaz")
            .MaximumLength(100).WithMessage("SKU en fazla 100 karakter olabilir");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Varyant fiyatı 0'dan büyük olmalıdır");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0'dan küçük olamaz");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Ürün ID boş olamaz");
    }
} 