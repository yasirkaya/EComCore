using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Rol adı boş olamaz")
            .MaximumLength(50).WithMessage("Rol adı en fazla 50 karakter olabilir");
    }
} 