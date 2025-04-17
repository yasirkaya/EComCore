using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class AttributeValueValidator : AbstractValidator<AttributeValue>
{
    public AttributeValueValidator()
    {
        RuleFor(x => x.AttributeId)
            .NotEmpty().WithMessage("Özellik ID boş olamaz");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Değer boş olamaz")
            .MaximumLength(100).WithMessage("Değer en fazla 100 karakter olabilir");
    }
} 