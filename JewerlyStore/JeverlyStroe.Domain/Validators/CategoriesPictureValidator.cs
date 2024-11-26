using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class CategoriesPictureValidator:AbstractValidator<CategoriesPicture>
{
    public CategoriesPictureValidator()
    {
        RuleFor(p=>p.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(p=>p.PathImg).NotEmpty().WithMessage("PathImg cannot be empty");
        RuleFor(p=>p.IdCategory).NotEmpty().WithMessage("IdCategory cannot be empty");
    }
}