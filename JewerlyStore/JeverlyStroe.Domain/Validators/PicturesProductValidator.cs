using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class PicturesProductValidator:AbstractValidator<PicturesProduct>
{
    public PicturesProductValidator()
    {
        RuleFor(p=>p.Id).NotEmpty().WithMessage("Id cannot be empty")
            .NotNull().WithMessage("Id cannot be null");
        RuleFor(p=>p.PathImg).NotEmpty().WithMessage("PathImg cannot be empty");
        RuleFor(p=>p.IdProduct).NotEmpty().WithMessage("IdProduct cannot be empty")
            .NotNull().WithMessage("IdProduct cannot be null");
    }
}