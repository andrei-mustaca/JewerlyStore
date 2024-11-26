using JeverlyStore.DAL.Interfaces;
using JeverlyStore.DAL.Storage;
using JeverlyStroe.Domain.ModelsDb;
using JewerlyStore.Service;
using JewerlyStore.Service.Interfaces;

namespace JewerlyStore;

public static class Initializer
{
    public static void InitializerRepozitories(this IServiceCollection services)
    {
        services.AddScoped<IBaseStorage<UserDb>, UserS>();
    }

    public static void InitializerServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization();
    }
}