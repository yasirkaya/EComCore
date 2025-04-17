using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class UserRoleValidator : AbstractValidator<UserRole>
{
    public UserRoleValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");

        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("Rol ID boş olamaz");
    }
} 