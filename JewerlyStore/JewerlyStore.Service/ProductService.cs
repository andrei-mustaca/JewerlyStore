using AutoMapper;
using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain;
using JeverlyStroe.Domain.Enum;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.ModelsDb;
using JeverlyStroe.Domain.Response;
using JewerlyStore.Service.Interfaces;

namespace JewerlyStore.Service;

public class ProductService:IProductService
{
    private readonly   IBaseStorage<ProductDb> _productStorage;
    private readonly IBaseStorage<PicturesProductDb> _pictureStorage;
    private IMapper _mapper { get; set; }

    private MapperConfiguration _mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public ProductService(IBaseStorage<ProductDb> productStorage,IBaseStorage<PicturesProductDb> pictureStorage)
    {
        _pictureStorage = pictureStorage;
        _productStorage = productStorage;
        _mapper = _mapperConfiguration.CreateMapper();
    }

    public BaseResponse<List<Product>> GetAllProductByIdCategories(Guid id)
    {
        try
        {
            var productDb=_productStorage.GetAll().Where(x=>id==x.IdCategories).OrderBy(p=>p.CreatedAt).ToList();
            var result=_mapper.Map<List<Product>>(productDb);
            if (result.Count == 0)
            {
                return new BaseResponse<List<Product>>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatucCode.OK
                };
            }

            return new BaseResponse<List<Product>>()
            {
                Data = result,
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<Product>>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public BaseResponse<List<Product>> GetProductByFilter(ProductFilter filter)
    {
        try
        {
            var productsFilter=GetAllProductByIdCategories(filter.IdProduct).Data;
            if (filter != null && productsFilter != null)
            {
                if (filter.PriceMax!=2000||filter.PriceMin!=0)
                {
                    productsFilter=productsFilter.Where(f=>f.Cost<filter.PriceMax&&f.Cost>filter.PriceMin).ToList();
                }
            }

            return new BaseResponse<List<Product>>()
            {
                Data = productsFilter,
                Description = "Отфильтрованные данные",
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<Product>>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<Product>> GetProductById(Guid id)
    {
        try
        {
            var productDb = await _productStorage.Get(id);
            var result = _mapper.Map<Product>(productDb);
            if (result==null)
            {
                return new BaseResponse<Product>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatucCode.OK
                };
            }
            return new BaseResponse<Product>()
            {
                Data = result,
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Product>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }

    public BaseResponse<List<PicturesProduct>> GetPictureByIdProduct(Guid id)
    {
        try
        {
            var pictureDb = _pictureStorage.GetAll().Where(x => id == x.IdProduct).ToList();
            var result = _mapper.Map<List<PicturesProduct>>(pictureDb);
            if (result.Count == 0)
            {
                return new BaseResponse<List<PicturesProduct>>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatucCode.OK
                };
            }

            return new BaseResponse<List<PicturesProduct>>()
            {
                Data = result,
                StatusCode = StatucCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<PicturesProduct>>()
            {
                Description = e.Message,
                StatusCode = StatucCode.InternalServerError
            };
        }
    }
}