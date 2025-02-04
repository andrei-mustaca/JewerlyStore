using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using JeverlyStore.DAL;
using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.Enum;
using JeverlyStroe.Domain.Helpers;
using JeverlyStroe.Domain.ModelsDb;
using JeverlyStroe.Domain.Response;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.Validators;
using JewerlyStore.Service.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace JewerlyStore.Service;

public class AccountService:IAccountService
{
    private readonly IBaseStorage<UserDb> _userStorage;
    private UserValidator _validationsrules { get; set; }
    private IMapper _mapper { get; set; }

    private MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public AccountService(IBaseStorage<UserDb> useStorage)
    {
        _userStorage = useStorage;
        _mapper = mapperConfiguration.CreateMapper();
        _validationsrules = new UserValidator();
    }

    public async Task<BaseResponse<ClaimsIdentity>> Login(User model)
    {
        try
        {
            await _validationsrules.ValidateAndThrowAsync(model);
            var userdb = await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (userdb == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (userdb.Password != HashPasswordHelper.HashPassword(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Неверный пароль или почта"
                };
            }

            model = _mapper.Map<User>(userdb);
            var result = AuthenticateUserHelper.Authenticate(model);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatucCode.OK
            };
        }
        catch (ValidationException exception)
        {
            var errorMessage=string.Join(";",exception.Errors.Select(e=>e.ErrorMessage));
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = errorMessage,
                StatusCode = StatucCode.BadRequest
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<string>> Register(User model)
    {
        try
        {
            Random random = new Random();
            string confirmationCode = $"{random.Next(10)}{random.Next(10)}{random.Next(10)}{random.Next(10)}";
            if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) != null)
            {
                return new BaseResponse<string>()
                {
                    Description = "Пользователь с такой почтой уже есть"
                };
            }

            await SendEmail(model.Email,confirmationCode);
            return new BaseResponse<string>()
            {
                Data = confirmationCode,
                Description = "Письмо отправлено",
                StatusCode = StatucCode.OK
            };
        }
        catch (ValidationException exception)
        {
            var errorMessage=string.Join(";",exception.Errors.Select(e=>e.ErrorMessage));
            return new BaseResponse<string>()
            {
                Description = errorMessage,
                StatusCode = StatucCode.BadRequest
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<string>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public async Task SendEmail(string email, string confirmationCode)
    {
        string path = "C:\\Users\\andre\\OneDrive\\Рабочий стол\\Учебная практика\\Password.txt";
        var emailMessage = new MimeMessage();
        
        emailMessage.From.Add(new MailboxAddress("Администрация сайта","Vdox.ru"));
        emailMessage.To.Add(new MailboxAddress("",email));
        emailMessage.Subject = "Добро пожаловать"!;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text="<html>"+"<head>"+"<style>"+
                 "body{font-family:Arial,sans-serif;background-color:#f2f2f2;}"+
                 ".container{max-width:600px;margin:0 auto;padding:20px;background-color:#fff;border-radius:10px; box-shadow:0px 0px 10px rgba(0,0,0,0.1);}"+
                 ".header{text-align:center;margin-bottom:20px;}"+
                 ".message{font-size:16px;line-height:1.6;}"+
                 ".conteiner-code{background-color:#f0f0f0;padding:5px;border-radius:5px;font-weight:bold;}"+
                 ".code {text-align:center;}"+
                 "</style>"+
                 "</head>"+
                 "<body>"+
                 "<div class='container'>"+
                 "<div class='header'><h1>Добро пожаловать на сайт ювелирного магазина Вдохновение</h1></div>"+
                 "<div class='message'>"+
                 "<p>Пожалуйста, введите данный код на сайте, чтобы подтвердить ваш email и завершить регистрацию:</p>"+
                 "<div class='conteiner-code'><p class='code'>"+confirmationCode+"</p></div>"+
                 "</div>"+"</div>"+"</body>"+"</html>"
        };
        using (StreamReader reader = new StreamReader(path))
        {
            string password = await reader.ReadToEndAsync();
            using (var client=new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com",465,true);
                await client.AuthenticateAsync("andrejmustaca6@gmail.com",password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> ConfirmEmail(User model, string code, string confirmationCode)
    {
        try
        {
            if (code != confirmationCode)
            {
                throw new Exception("Неверный код! Регистрация не выполнена.");
            }
            model.PathImage = "/Images/designer.jpg";
            model.CreatedAt=DateTime.Now;
            model.Password=HashPasswordHelper.HashPassword(model.Password);
            
            await _validationsrules.ValidateAndThrowAsync(model);
            
            var userdb=_mapper.Map<UserDb>(model);
            await _userStorage.Add(userdb);
            
            var result = AuthenticateUserHelper.Authenticate(model);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Объект добавился",
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> IsCreatedAccount(User model)
    {
        try
        {
            var userdb = new UserDb();
            if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) == null)
            {
                model.Password = HashPasswordHelper.HashPassword("google");
                model.CreatedAt = DateTime.Now;
                
                userdb=_mapper.Map<UserDb>(model);

                await _userStorage.Add(userdb);

                var resultRegister = AuthenticateUserHelper.Authenticate(model);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = resultRegister,
                    Description = "Объект добавился",
                    StatusCode = StatucCode.OK
                };
            }
            var resultLogin = AuthenticateUserHelper.Authenticate(model);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = resultLogin,
                Description = "Объект уже был создан",
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }
    
    public User GetUserByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));

        // Поиск пользователя в базе данных
        var user = _userStorage.GetAll().FirstOrDefault(u => u.Email == email);
        User users = _mapper.Map<User>(user);
        return users;
    }
}