using FluentValidation;
using EComCore.Domain.Entities;

namespace EComCore.Application.Validators;

public class ShipmentValidator : AbstractValidator<Shipment>
{
    public ShipmentValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Sipariş ID boş olamaz");

        RuleFor(x => x.TrackingNumber)
            .NotEmpty().WithMessage("Takip numarası boş olamaz")
            .MaximumLength(50).WithMessage("Takip numarası en fazla 50 karakter olabilir");

        RuleFor(x => x.Carrier)
            .NotEmpty().WithMessage("Kargo firması boş olamaz")
            .MaximumLength(50).WithMessage("Kargo firması en fazla 50 karakter olabilir");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Durum boş olamaz")
            .MaximumLength(50).WithMessage("Durum en fazla 50 karakter olabilir");
    }
} 