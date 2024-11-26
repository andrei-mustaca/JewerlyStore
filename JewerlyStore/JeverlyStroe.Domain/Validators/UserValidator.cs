using FluentValidation;
using JeverlyStroe.Domain.Models;

namespace JeverlyStroe.Domain.Validators;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Password).NotEmpty().WithMessage("Пароль обязателен")
            .MinimumLength(6).WithMessage("Пароль должен содержать минимум 6 символов");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Электронная почта обязательна")
            .EmailAddress().WithMessage("Неверный формат Email");
    }
}