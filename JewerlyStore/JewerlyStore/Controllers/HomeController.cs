using System.Diagnostics;
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
}