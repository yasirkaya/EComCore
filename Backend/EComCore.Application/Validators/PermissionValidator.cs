using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class PermissionValidator : AbstractValidator<Permission>
{
    public PermissionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İzin adı boş olamaz")
            .MaximumLength(100).WithMessage("İzin adı en fazla 100 karakter olabilir");
    }
} 