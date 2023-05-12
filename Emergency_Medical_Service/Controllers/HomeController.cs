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
            _loginModel.LoggedIn = true;
            return RedirectToAction("Error");
        }
        else
        {
            return RedirectToAction("Error");
        }
    }

    public IActionResult Responds()
    {
        var responds = _service.GetAllResponds().GetAwaiter().GetResult();
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        var patients = _service.GetAllPatients().GetAwaiter().GetResult();
        var cars = _service.GetAllCars().GetAwaiter().GetResult();

        foreach (var item in responds)
        {
            item.DoctorModel = doctors.FirstOrDefault(x => x.DoctorId == item.DoctorId);
            item.PatientModel = patients.FirstOrDefault(x => x.PatientId == item.PatientId);
            item.CarModel = cars.FirstOrDefault(x => x.CarId == item.CarId);
        }

        return View(responds);
    }

    public IActionResult Patients()
    {
        return View();
    }

    public IActionResult Doctors()
    {
        return View();
    }

    public IActionResult Cars()
    {
        return View();
    }

    public IActionResult Hospitals()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}