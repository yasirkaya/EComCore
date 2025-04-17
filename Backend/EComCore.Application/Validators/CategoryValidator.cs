using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir");
    }
} 