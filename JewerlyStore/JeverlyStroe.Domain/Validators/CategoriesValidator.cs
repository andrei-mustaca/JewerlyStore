using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class CategoriesValidator:AbstractValidator<Categories>
{
    public CategoriesValidator()
    {
        RuleFor(categories=>categories.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(categories=>categories.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(categories=>categories.IdImg).NotEmpty().WithMessage("IdImg cannot be empty");
        RuleFor(categories=>categories.CreatedAt).NotEmpty().WithMessage("CreatedAt cannot be empty");
    }
}