using System.Diagnostics;
using JeverlyStroe.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JewerlyStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
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
    public IActionResult Login([FromBody] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok(model); 
        }

        var errors = ModelState.Values.SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
        return BadRequest(errors);
    }

    [HttpPost]
    public IActionResult Register([FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var errors=ModelState.Values.SelectMany(v => v.Errors)
                .Select(e=>e.ErrorMessage)
                .ToList();
            return BadRequest(errors);
        }
        return Ok(model);
    }
}