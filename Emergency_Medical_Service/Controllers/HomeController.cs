using System.Diagnostics;
using Emergency_Medical_Service.Attributes;
using Microsoft.AspNetCore.Mvc;
using Emergency_Medical_Service.Models;
using Emergency_Medical_Service.Services;
using EMS.Lib.Enums;
using EMS.Lib.Models;

namespace Emergency_Medical_Service.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EMSService _service;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _service = new EMSService();
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        string cookie = Request.Cookies["doctorId"];
        if (string.IsNullOrEmpty(cookie))
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        return RedirectToAction("Responds");
    }
    
    [HttpPost]
    public IActionResult Index(LoginModel loginModel)
    {
        var doctor = _service.GetAllDoctors().GetAwaiter().GetResult()
            .FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

        if (doctor != null)
        {
            Response.Cookies.Append("doctorId", doctor.DoctorId.ToString());
            return RedirectToAction("Responds");
        }
        else
        {
            return RedirectToAction("Error");
        }
    }
    
    [Authentication]
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
    
    [Authentication]
    public IActionResult Patients()
    {
        var patients = _service.GetAllPatients().GetAwaiter().GetResult();
        
        return View(patients);
    }
    
    [Authentication]
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
    
    [Authentication]
    public IActionResult Cars()
    {
        var cars = _service.GetAllCars().GetAwaiter().GetResult();
        
        return View(cars);
    }

    [Authentication]
    public IActionResult Hospitals()
    {
        var hospitals = _service.GetAllHospitals().GetAwaiter().GetResult();
        
        return View(hospitals);
    }

    [Authentication]
    [HttpGet]
    public IActionResult AddRespond()
    {
        RespondModel r = new RespondModel();
        r.Doctors = _service.GetAllDoctors().GetAwaiter().GetResult().ToList();
        r.Patients = _service.GetAllPatients().GetAwaiter().GetResult().ToList();
        r.Cars = _service.GetAllCars().GetAwaiter().GetResult().ToList();
        

        return View(r);
    }
    
    [Authentication]
    [HttpPost]
    public async Task<IActionResult> AddRespond(RespondModel r)
    {
        r.Date = DateTime.Now.ToShortDateString();
        await _service.AddRespond(r);

        return RedirectToAction("Responds");
    }

    [Authentication]
    [HttpGet]
    public IActionResult AddDoctor()
    {
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        
        string cookie = Request.Cookies["doctorId"];

        if (!string.IsNullOrEmpty(cookie))
        {
            var foundDoctor = doctors.FirstOrDefault(x => x.DoctorId == int.Parse(cookie));

            if (foundDoctor.Rank == Rank.Head || foundDoctor.Rank == Rank.Dean)
            {
                DoctorModel d = new DoctorModel();
                d.Hospitals = _service.GetAllHospitals().GetAwaiter().GetResult().ToList();
        
                return View(d);
            }
            return RedirectToAction("Doctors");
        }

        return RedirectToAction("Doctors");
    }

    [Authentication]
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

    [Authentication]
    [HttpPost]
    public async Task<IActionResult> AddPatient(PatientModel p)
    {
        p.Birthday.ToString();
        
        await _service.AddPatient(p);

        return RedirectToAction("Patients");
    }

    [Authentication]
    [HttpGet]
    public IActionResult AddCar()
    {
        CarModel c = new CarModel();

        return View(c);
    }

    [Authentication]
    [HttpPost]
    public async Task<IActionResult> AddCar(CarModel c)
    {
        await _service.AddCar(c);

        return RedirectToAction("Cars");
    }

    [Authentication]
    [HttpGet]
    public IActionResult AddHospital()
    {
        HospitalModel h = new HospitalModel();

        return View(h);
    }

    [Authentication]
    [HttpPost]
    public async Task<IActionResult> AddHospital(HospitalModel h)
    {
        await _service.AddHospital(h);

        return RedirectToAction("Hospitals");
    }
    
    public async Task<IActionResult> DeleteRespond(RespondModel model)
    {
        await _service.DeleteRespond(model);

        return RedirectToAction("Responds");
    }

    public async Task<IActionResult> DeletePatient(PatientModel model)
    {
        await _service.DeletePatient(model);

        return RedirectToAction("Patients");
    }

    public async Task<IActionResult> DeleteDoctor(DoctorModel model)
    {
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        
        string cookie = Request.Cookies["doctorId"];

        if (!string.IsNullOrEmpty(cookie))
        {
            var foundDoctor = doctors.FirstOrDefault(x => x.DoctorId == int.Parse(cookie));

            if (foundDoctor.DoctorId != model.DoctorId)
            {
                if (foundDoctor.Rank == Rank.Dean || foundDoctor.Rank == Rank.Head)
                {
                    if (model == null)
                    {
                        return RedirectToAction("Doctors");
                    }
                    
                    await _service.DeleteDoctor(model);
                }
            }
            
            return RedirectToAction("Doctors");
        }
        
        return RedirectToAction("Doctors");
    }

    public async Task<IActionResult> DeleteCar(CarModel model)
    {
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        
        string cookie = Request.Cookies["doctorId"];

        if (!string.IsNullOrEmpty(cookie))
        {
            var foundDoctor = _service.GetAllDoctors().GetAwaiter().GetResult()
                .First(x => x.DoctorId == int.Parse(cookie));

            if (foundDoctor.Rank != Rank.Dean || foundDoctor.Rank != Rank.Head)
            {
                return RedirectToAction("Cars");
            }
            if (model == null)
            {
                    return RedirectToAction("Cars");
            }
            await _service.DeleteCar(model);
        }
        return RedirectToAction("Hospitals");
    }

    public async Task<IActionResult> DeleteHospital(HospitalModel model)
    {
        var doctors = _service.GetAllDoctors().GetAwaiter().GetResult();
        
        string cookie = Request.Cookies["doctorId"];

        if (string.IsNullOrEmpty(cookie))
        {
            var foundDoctor = _service.GetAllDoctors().GetAwaiter().GetResult()
                .First(x => x.DoctorId == int.Parse(cookie));

            if (foundDoctor.Rank == Rank.Train)
            {
                return RedirectToAction("Hospitals");
            }
            else
            {
                if (model == null)
                {
                    return RedirectToAction("Hospitals");
                }
                await _service.DeleteHospital(model);
                
            }
        }
        return RedirectToAction("Hospitals");
    }

    
    [HttpGet]
    public IActionResult EditRespond(int id)
    {
        var model = _service.GetAllResponds().GetAwaiter().GetResult().FirstOrDefault(x => x.RespondId == id);
        model.Cars = _service.GetAllCars().GetAwaiter().GetResult().ToList();
        model.Patients = _service.GetAllPatients().GetAwaiter().GetResult().ToList();
        model.Doctors = _service.GetAllDoctors().GetAwaiter().GetResult().ToList();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditRespond(RespondModel editedRespond)
    {
        editedRespond.Date = DateTime.Now.ToShortDateString();

        await  _service.EditRespond(editedRespond);

        return RedirectToAction("Responds");
    }

    [HttpGet]
    public IActionResult EditPatient(int id)
    {
        var model = _service.GetAllPatients().GetAwaiter().GetResult().FirstOrDefault(x => x.PatientId == id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditPatient(PatientModel editedPatient)
    {
        await _service.EditPatient(editedPatient);
        
        return RedirectToAction("Patients");
    }

    [HttpGet]
    public IActionResult EditDoctor(int id)
    {
        var model = _service.GetAllDoctors().GetAwaiter().GetResult().FirstOrDefault(x => x.DoctorId == id);
        model.Hospitals = _service.GetAllHospitals().GetAwaiter().GetResult().ToList();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditDoctor(DoctorModel editedDoctor)
    {
        await _service.EditDoctor(editedDoctor);

        return RedirectToAction("Doctors");
    }

    [HttpGet]
    public IActionResult EditCar(int id)
    {
        var model = _service.GetAllCars().GetAwaiter().GetResult().FirstOrDefault(x => x.CarId == id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditCar(CarModel editedCar)
    {
        await _service.EditCar(editedCar);

        return RedirectToAction("Cars");
    }

    [HttpGet]
    public IActionResult EditHospital(int id)
    {
        var model = _service.GetAllHospitals().GetAwaiter().GetResult().FirstOrDefault(x => x.HospitalId == id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditHospital(HospitalModel editedHospital)
    {
        await _service.EditHospital(editedHospital);

        return RedirectToAction("Hospitals");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}