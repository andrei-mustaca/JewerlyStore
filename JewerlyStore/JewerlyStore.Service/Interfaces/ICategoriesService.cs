using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.Response;

namespace JewerlyStore.Service.Interfaces;

public interface ICategoriesService
{
    BaseResponse<List<Categories>>  GetAllCategories();
}