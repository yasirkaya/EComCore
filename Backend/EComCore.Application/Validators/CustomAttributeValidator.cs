using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class CustomAttributeValidator : AbstractValidator<CustomAttribute>
{
    public CustomAttributeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Özellik adı boş olamaz")
            .MaximumLength(100).WithMessage("Özellik adı en fazla 100 karakter olabilir");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
    }
} 