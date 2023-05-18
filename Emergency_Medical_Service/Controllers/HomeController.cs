using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices.JavaScript;
using Emergency_Medical_Service.Attributes;
using Microsoft.AspNetCore.Mvc;
using Emergency_Medical_Service.Models;
using Emergency_Medical_Service.Services;
using EMS.Lib.Models;

namespace Emergency_Medical_Service.Controllers;

[Authentication]
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
        var patients = _service.GetAllPatients().GetAwaiter().GetResult();
        
        return View(patients);
    }
    
    public IActionResult Doctors()
    {
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        var hospitals = _service.GetAllHospitals().GetAwaiter().GetResult();

        foreach (var doctor in doctors)
        {
            doctor.HospitalModel = hospitals.FirstOrDefault(x => x.HospitalId == doctor.HospitalId);
        }
        
        return View(doctors);
    }
    
    public IActionResult Cars()
    {
        var cars = _service.GetAllCars().GetAwaiter().GetResult();
        
        return View(cars);
    }

    public IActionResult Hospitals()
    {
        var hospitals = _service.GetAllHospitals().GetAwaiter().GetResult();
        
        return View(hospitals);
    }

    [HttpGet]
    public IActionResult AddRespond()
    {
        RespondModel r = new RespondModel();
        r.Doctors = _service.GetAllDoctors().GetAwaiter().GetResult().ToList();
        r.Patients = _service.GetAllPatients().GetAwaiter().GetResult().ToList();
        r.Cars = _service.GetAllCars().GetAwaiter().GetResult().ToList();
        

        return View(r);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRespond(RespondModel r)
    {
        r.Date = DateTime.Now.ToShortDateString();
        await _service.AddRespond(r);

        return RedirectToAction("Responds");
    }

    [HttpGet]
    public IActionResult AddDoctor()
    {
        DoctorModel d = new DoctorModel();
        d.Hospitals = _service.GetAllHospitals().GetAwaiter().GetResult().ToList();
        
        return View(d);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctor(DoctorModel d)
    {
        d.Birthday.ToString();
        
        await _service.AddDoctor(d);

        return RedirectToAction("Doctors");
    }

    [HttpGet]
    public IActionResult AddPatient()
    {
        PatientModel p = new PatientModel();

        return View(p);
    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(PatientModel p)
    {
        p.Birthday.ToString();
        
        await _service.AddPatient(p);

        return RedirectToAction("Patients");
    }

    [HttpGet]
    public IActionResult AddCar()
    {
        CarModel c = new CarModel();

        return View(c);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar(CarModel c)
    {
        await _service.AddCar(c);

        return RedirectToAction("Cars");
    }

    [HttpGet]
    public IActionResult AddHospital()
    {
        HospitalModel h = new HospitalModel();

        return View(h);
    }

    [HttpPost]
    public async Task<IActionResult> AddHospital(HospitalModel h)
    {
        await _service.AddHospital(h);

        return RedirectToAction("Hospitals");
    }

    [HttpGet]
    public IActionResult DeleteRespond(int respondId)
    {
        var respond = _service.GetAllResponds().GetAwaiter().GetResult()
            .FirstOrDefault(x => x.RespondId == respondId);

        return View(respond);
    }

    [HttpPost]
    public IActionResult DeleteRespond(RespondModel model)
    {
        var respond = _service.GetAllResponds().GetAwaiter().GetResult()
            .FirstOrDefault(x => x.RespondId == model.RespondId);
        
        if (respond == null)
        {
            return RedirectToAction("Responds");
        }

        _service.DeleteRespond(respond.RespondId);

        return RedirectToAction("Responds");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}