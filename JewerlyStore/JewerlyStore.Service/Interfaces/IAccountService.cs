using JeverlyStroe.Domain;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.Response;

namespace JewerlyStore.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<User>> Register(User model);

    Task<BaseResponse<User>> Login(User model);
}