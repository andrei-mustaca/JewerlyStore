using AutoMapper;
using JeverlyStore.DAL;
using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.Enum;
using JeverlyStroe.Domain.ModelsDb;
using JeverlyStroe.Domain.Response;
using JeverlyStroe.Domain.Models;
using JewerlyStore.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewerlyStore.Service;

public class AccountService:IAccountService
{
    private readonly IBaseStorage<UserDb> _userStorage;
    private IMapper _mapper { get; set; }

    private MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public AccountService(IBaseStorage<UserDb> useStorage)
    {
        _userStorage = useStorage;
        _mapper = mapperConfiguration.CreateMapper();
    }

    public async Task<BaseResponse<User>> Login(User model)
    {
        try
        {
            var userdb = _mapper.Map<UserDb>(model);
            if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) == null)
            {
                return new BaseResponse<User>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (userdb.Password != model.Password)
            {
                return new BaseResponse<User>()
                {
                    Description = "Неверный пароль или почта"
                };
            }

            return new BaseResponse<User>()
            {
                Data = model,
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Description = ex.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<User>> Register(User model)
    {
        try
        {
            model.PathImage = "/Images/designer.jpg";
            model.CreatedAt=DateTime.Now;

            var userdb = _mapper.Map<UserDb>(model);
            if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) != null)
            {
                return new BaseResponse<User>()
                {
                    Description = "Пользователь с такой почтой уже есть"
                };
            }

            await _userStorage.Add(userdb);
            return new BaseResponse<User>()
            {
                Data = model,
                Description = "Пользователь зарегистрирован",
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<User>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }
}