using System.Security.Claims;
using JeverlyStroe.Domain;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.Response;

namespace JewerlyStore.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<string>> Register(User model);
    Task<BaseResponse<ClaimsIdentity>> Login(User model);
    Task<BaseResponse<ClaimsIdentity>>ConfirmEmail(User model, string code,string confirmationCode);
}