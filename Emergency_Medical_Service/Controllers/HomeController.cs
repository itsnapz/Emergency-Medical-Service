using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Emergency_Medical_Service.Models;
using Emergency_Medical_Service.Services;
using EMS.Lib.Models;

namespace Emergency_Medical_Service.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EMSService _service;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _service = new();
    }

    [HttpGet]
    public IActionResult Index()
    {
        LoginModel _loginModel = new LoginModel();
        return View(_loginModel);
    }
    [HttpPost]
    public IActionResult Index(LoginModel _loginModel)
    {
        var doctor = _service.GetAllDoctors().GetAwaiter().GetResult()
            .FirstOrDefault(x => x.Email == _loginModel.Email && x.Password == _loginModel.Password);

        if (doctor != null)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Error");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}