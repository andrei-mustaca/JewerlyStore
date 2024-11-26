using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class ComplaintValidator:AbstractValidator<Complaint>
{
    public ComplaintValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(c=>c.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(c=>c.IdOrders).NotEmpty().WithMessage("IdOrders cannot be empty");
        RuleFor(c=>c.IdUser).NotEmpty().WithMessage("IdUser cannot be empty");
    }
}