using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class OrderValidator:AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(o=>o.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(o=>o.Cost).NotEmpty().WithMessage("Cost cannot be empty")
            .GreaterThan(0).WithMessage("Cost should be greater than 0");
        RuleFor(o=>o.CreatedAt).NotEmpty().WithMessage("CreatedAt cannot be empty");
        RuleFor(o=>o.IdUser).NotEmpty().WithMessage("IdUser cannot be empty");
        RuleFor(o=>o.IdRequest).NotEmpty().WithMessage("IdRequest cannot be empty");
        RuleFor(o=>o.IdProduct).NotEmpty().WithMessage("IdProduct cannot be empty");
    }
}