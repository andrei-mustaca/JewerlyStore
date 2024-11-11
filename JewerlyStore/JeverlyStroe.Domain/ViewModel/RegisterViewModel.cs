using System.ComponentModel.DataAnnotations;

namespace JeverlyStroe.Domain.ViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Укажите имя 3-20 символов")]
    [MaxLength(20,ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
    [MinLength(3,ErrorMessage = "Имя должно иметь длину больше 3 символов")]
    public string Login { get; set; }
    
    [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
    [Required(ErrorMessage = "Укажите пароль")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(6,ErrorMessage = "Пароль должен содержать длину больше 6 символов")]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare("Password",ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
}