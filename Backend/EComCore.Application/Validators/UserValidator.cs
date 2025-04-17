using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
            .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz")
            .MaximumLength(100).WithMessage("E-posta adresi en fazla 100 karakter olabilir");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Şifre boş olamaz");
    }
} 