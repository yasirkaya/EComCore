using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class RolePermissionValidator : AbstractValidator<RolePermission>
{
    public RolePermissionValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("Rol ID boş olamaz");

        RuleFor(x => x.PermissionId)
            .NotEmpty().WithMessage("İzin ID boş olamaz");
    }
} 