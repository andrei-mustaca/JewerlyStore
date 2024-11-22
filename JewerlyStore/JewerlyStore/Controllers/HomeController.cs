using System.Diagnostics;
using AutoMapper;
using JeverlyStroe.Domain.Enum;
using JeverlyStroe.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using JeverlyStroe.Domain.Models;
using JewerlyStore.Service;

namespace JewerlyStore.Controllers;

public class HomeController : Controller
{
    private IMapper _mapper { get; set; }
    private readonly ILogger<HomeController> _logger;
    private AccountService _accountService { get; set; }
    private MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
    {
        p.AddProfile<AppMappingProfile>();
    }); 
    public HomeController(ILogger<HomeController> logger)
    {
        _mapper = mapperConfiguration.CreateMapper();
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("SiteInformation");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SiteInformation()
    {
        return View();
    }

    public IActionResult Main()
    {
        return View();
    }

    public IActionResult CustomProduct()
    {
        return View();
    }

    public IActionResult Contacts()
    {
        return View();
    }

    public IActionResult Complaints()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _mapper.Map<User>(model);

            var response = await _accountService.Login(user);
            if (response.StatusCode == StatucCode.OK)
            {
                return Ok(model);
            }
            ModelState.AddModelError("",response.Description);
        }

        var errors = ModelState.Values.SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
        return BadRequest(errors);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var user = _mapper.Map<User>(model);
            var response = await _accountService.Register(user);
            if (response.StatusCode==StatucCode.OK)
            {
                return Ok(model);
            }
            ModelState.AddModelError("",response.Description);
        }
        var errors=ModelState.Values.SelectMany(v => v.Errors)
            .Select(e=>e.ErrorMessage)
            .ToList();
        return BadRequest(errors);
    }
}