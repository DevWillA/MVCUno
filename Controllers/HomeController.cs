using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Mensaje1"] = "Este es un mensaje desde el controlador con viewdata";
        ViewBag.Mensaje2 = "Este es un mensaje desde el controlador!!!!!";
        ViewBag.Contador = 10;
        ViewData["Contador2"] = 20;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult VistaDemo()
    {
        ViewBag.Title = "Vista Demo"; /// Para agregar el titulo en la pestaña
        return View();
    }
}
