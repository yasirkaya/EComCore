using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Adres adı boş olamaz")
            .MaximumLength(100).WithMessage("Adres adı en fazla 100 karakter olabilir");

        RuleFor(x => x.AddressLine1)
            .NotEmpty().WithMessage("Adres satırı 1 boş olamaz")
            .MaximumLength(200).WithMessage("Adres satırı 1 en fazla 200 karakter olabilir");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Şehir boş olamaz")
            .MaximumLength(50).WithMessage("Şehir en fazla 50 karakter olabilir");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Posta kodu boş olamaz")
            .MaximumLength(10).WithMessage("Posta kodu en fazla 10 karakter olabilir");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");
    }
} 