using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using investTools.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace investTools.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Dashboard");       // LInha alterada
    }

    public IActionResult Dashboard()        // Método inserido
    {
        return View();
    }

    public IActionResult Buttons()          // Método inserido
    {
        return View();
    }

    public IActionResult Cards()            // Método inserido
    {
        return View();
    }

    public IActionResult Colors()           // Método inserido
    {
        return View();
    }

    public IActionResult Borders()          // Método inserido
    {
        return View();
    }

    public IActionResult Animations()       // Método inserido
    {
        return View();
    }

    public IActionResult Others()           // Método inserido
    {
        return View();
    }

    public IActionResult Login()            // Método inserido
    {
        ViewBag.Title = "Login";

        return View();
    }

    public IActionResult Register()         // Método inserido
    {
        ViewBag.Title = "Registro de Usuário";

        return View();
    }

    public IActionResult ForgotPassword()   // Método inserido
    {
        return View();
    }

    public IActionResult Page404()          // Método inserido
    {
        return View();
    }

    public IActionResult BlankPage()        // Método inserido
    {
        return View();
    }

    public IActionResult Charts()           // Método inserido
    {
        return View();
    }

    public IActionResult Tables()           // Método inserido
    {
        return View();
    }

}
