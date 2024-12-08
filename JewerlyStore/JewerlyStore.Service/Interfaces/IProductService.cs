using JeverlyStroe.Domain;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.Response;

namespace JewerlyStore.Service.Interfaces;

public interface IProductService
{
    BaseResponse<List<Product>> GetAllProductByIdCategories(Guid id);
    BaseResponse<List<Product>> GetProductByFilter(ProductFilter filter);

    Task<BaseResponse<Product>> GetProductById(Guid id);
    BaseResponse<List<PicturesProduct>> GetPictureByIdProduct(Guid id);
}