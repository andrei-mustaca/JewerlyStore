using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class RequestValidator:AbstractValidator<Request>
{
    public RequestValidator()
    {
        RuleFor(p=>p.Id).NotEmpty().WithMessage("Id cannot be empty")
            .NotNull().WithMessage("Id cannot be null");
        RuleFor(p=>p.IdUser).NotEmpty().WithMessage("IdRequest cannot be empty")
            .NotNull().WithMessage("IdRequest cannot be null");
        RuleFor(p=>p.Description).NotEmpty().WithMessage("Description cannot be empty")
            .NotNull().WithMessage("Description cannot be null");
        RuleFor(p=>p.CreatedAt).NotEmpty().WithMessage("CreatedAt cannot be empty")
            .NotNull().WithMessage("CreatedAt cannot be null");
        RuleFor(p=>p.Status).NotEmpty().WithMessage("Status cannot be empty")
            .NotNull().WithMessage("Status cannot be null");
        RuleFor(p=>p.IdOrder).NotEmpty().WithMessage("IdRequest cannot be empty")
            .NotNull().WithMessage("IdRequest cannot be null");
    }
}