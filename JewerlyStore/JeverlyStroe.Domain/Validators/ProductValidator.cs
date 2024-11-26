using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class ProductValidator:AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p=>p.Id).NotNull().WithMessage("Id")
            .NotEmpty().WithMessage("Id");
        RuleFor(p => p.Cost).NotEmpty().WithMessage("Cost cannot be empty")
            .GreaterThan(0).WithMessage("Cost must be greater than 0")
            .NotNull().WithMessage("Cost cannot be null");
        RuleFor(p => p.Name).NotNull().WithMessage("Name cannot be empty")
            .NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(p=>p.IdCategories).NotNull().WithMessage("IdCategories cannot be empty")
            .NotEmpty().WithMessage("IdCategories cannot be empty");
        RuleFor(p=>p.CreatedAt).NotNull().WithMessage("CreatedAt cannot be empty")
            .NotEmpty().WithMessage("CreatedAt cannot be empty");
    }
}