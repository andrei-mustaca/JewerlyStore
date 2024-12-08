using AutoMapper;
using JeverlyStroe.Domain.Models;
using JeverlyStroe.Domain.ModelsDb;
using JeverlyStroe.Domain.ViewModel;

namespace JewerlyStore.Service;

public class AppMappingProfile:Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserDb>().ReverseMap();
        CreateMap<User, LoginViewModel>().ReverseMap();
        CreateMap<User, RegisterViewModel>().ReverseMap();
        CreateMap<RegisterViewModel,ConfirmEmailViewModel>().ReverseMap();
        CreateMap<User,ConfirmEmailViewModel>().ReverseMap();

        CreateMap<Categories,CategoriesDb>().ReverseMap();
        CreateMap<Categories, CategoriesViewModel>().ReverseMap();

        CreateMap<Product,ProductDb>().ReverseMap();
        CreateMap<Product,ProductForListOfProductViewModel>().ReverseMap();
        CreateMap<Product, ProductPageViewModel>().ReverseMap();

        CreateMap<PicturesProduct, PicturesProductDb>().ReverseMap();
        CreateMap<PicturesProduct, PictureViewModel>().ReverseMap();
    }
}