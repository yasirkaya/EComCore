using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ürün adı boş olamaz")
            .MaximumLength(255).WithMessage("Ürün adı en fazla 255 karakter olabilir");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Ürün açıklaması boş olamaz")
            .MaximumLength(1000).WithMessage("Ürün açıklaması en fazla 1000 karakter olabilir");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");

        RuleFor(x => x.SKU)
            .NotEmpty().WithMessage("SKU boş olamaz")
            .MaximumLength(100).WithMessage("SKU en fazla 100 karakter olabilir");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0'dan küçük olamaz");

        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage("Grup ID boş olamaz");

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5).WithMessage("Değerlendirme 0-5 arasında olmalıdır");
    }
} 