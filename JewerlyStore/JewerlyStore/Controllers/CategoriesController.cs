using AutoMapper;
using JeverlyStroe.Domain.ViewModel;
using JewerlyStore.Service;
using JewerlyStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewerlyStore.Controllers;

public class CategoriesController:Controller
{
    private readonly ICategoriesService _countryService;
    private IMapper _mapper { get; set; }

    private MapperConfiguration _mapperConfiguration = new MapperConfiguration(p=>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public CategoriesController(ICategoriesService categoriesService)
    {
        _countryService = categoriesService;
        _mapper = _mapperConfiguration.CreateMapper();
    }
    public IActionResult ListOfCategories()
    {
        var result = _countryService.GetAllCategories();
        var listOfCategories = _mapper.Map<List<CategoriesViewModel>>(result.Data);
        return View(listOfCategories);
    }
}