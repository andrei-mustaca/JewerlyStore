using AutoMapper;
using JeverlyStroe.Domain;
using JeverlyStroe.Domain.ViewModel;
using JewerlyStore.Service;
using JewerlyStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewerlyStore.Controllers;

public class ProductsController:Controller
{
    private readonly IProductService _productService;
    private IMapper _mapper { get; set; }

    private MapperConfiguration _mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    });

    public ProductsController(IProductService productService)
    {
        _productService = productService;
        _mapper = _mapperConfiguration.CreateMapper();
    }

    public IActionResult ListOfProducts(Guid id)
    {
        var result = _productService.GetAllProductByIdCategories(id);
        ListOfProductViewModel listProduct = new ListOfProductViewModel
        {
            Products = _mapper.Map<List<ProductForListOfProductViewModel>>(result.Data),
            IdCategories = id
        };
        return View(listProduct);
    }

    [HttpPost]
    public async Task<IActionResult> Filter([FromBody] ProductFilter filter)
    {
        var result = _productService.GetProductByFilter(filter);
        var filteredProducts = _mapper.Map<List<ProductForListOfProductViewModel>>(result.Data);
        return Ok(filteredProducts);
    }

    public async Task<IActionResult> ProductPage(Guid id)
    {
        var resultProduct = await _productService.GetProductById(id);
        var resultPicture = _productService.GetPictureByIdProduct(id);
        ProductPageViewModel product = _mapper.Map<ProductPageViewModel>(resultProduct.Data);
        product.PictureViewModels = _mapper.Map<List<PictureViewModel>>(resultPicture.Data);

        return View(product);
    }
}