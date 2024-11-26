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
using Microsoft.EntityFrameworkCore;

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

    public async Task<BaseResponse<ClaimsIdentity>> Register(User model)
    {
        try
        {
            model.PathImage = "/Images/designer.jpg";
            model.CreatedAt=DateTime.Now;
            model.Password = HashPasswordHelper.HashPassword(model.Password);

            await _validationsrules.ValidateAndThrowAsync(model);

            var userdb = _mapper.Map<UserDb>(model);
            if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с такой почтой уже есть"
                };
            }

            await _userStorage.Add(userdb);
            var result = AuthenticateUserHelper.Authenticate(model);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Пользователь зарегистрирован",
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
        catch (Exception e)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }
}