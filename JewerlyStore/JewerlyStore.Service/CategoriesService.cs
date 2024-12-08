using AutoMapper;
using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.Enum;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.ModelsDb;
using JeverlyStroe.Domain.Response;
using JeverlyStroe.Domain.Validators;
using JewerlyStore.Service.Interfaces;

namespace JewerlyStore.Service;

public class CategoriesService:ICategoriesService
{
    private readonly IBaseStorage<CategoriesDb> _categoriesStorage;
    private IMapper _mapper { get; set; }
    private CategoriesValidator _validator { get; set; }

    private MapperConfiguration _mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public CategoriesService(IBaseStorage<CategoriesDb> categoriesStorage)
    {
        _categoriesStorage = categoriesStorage;
        _mapper = _mapperConfiguration.CreateMapper();
        _validator=new CategoriesValidator();
    }

    public BaseResponse<List<Categories>> GetAllCategories()
    {
        try
        {
            var categoriesdb=_categoriesStorage.GetAll().OrderBy(p=>p.CreatedAt).ToList();
            var result=_mapper.Map<List<Categories>>(categoriesdb);
            if (result.Count == 0)
            {
                return new BaseResponse<List<Categories>>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatucCode.OK
                };
            }

            return new BaseResponse<List<Categories>>()
            {
                Data = result,
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<Categories>>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }
}