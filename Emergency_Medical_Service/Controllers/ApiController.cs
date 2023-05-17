using Emergency_Medical_Service.Services;
using EMS.Lib;
using EMS.Lib.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Emergency_Medical_Service.Controllers;

[ApiController]
public class ApiController : Controller
{
    private readonly APIService _service;

    public ApiController(APIService service)
    {
        _service = service;
    }

    [HttpGet(Endpoints.GET_RESPONDS)]
    public IEnumerable<RespondModel> GetAllResponds()
    {
        return _service.GetAllResponds().Result;
    }

    [HttpGet(Endpoints.GET_PATIENTS)]
    public IEnumerable<PatientModel> GetAllPatients()
    {
        return _service.GetAllPatients().Result;
    }

    [HttpGet(Endpoints.GET_DOCTORS)]
    public IEnumerable<DoctorModel> GetAllDoctors()
    {
        return _service.GetAllDoctors().Result;
    }

    [HttpGet(Endpoints.GET_CARS)]
    public IEnumerable<CarModel> GetAllCars()
    {
        return _service.GetAllCars().Result;
    }

    [HttpGet(Endpoints.GET_HOSPITALS)]
    public IEnumerable<HospitalModel> GetAllHospitals()
    {
        return _service.GetAllHospitals().Result;
    }

    [HttpGet(Endpoints.GET_DOCTOR_BY_ID)]
    public DoctorModel GetDoctorById(int doctorId)
    {
        return _service.GetDoctorById(doctorId).Result;
    }

    [HttpGet(Endpoints.GET_RESPOND_BY_ID)]
    public RespondModel GetRespondById(int respondId)
    {
        return _service.GetRespondById(respondId).Result;
    }

    [HttpGet(Endpoints.GET_PATIENT_BY_ID)]
    public PatientModel GetPatientById(int patientId)
    {
        return _service.GetPatientById(patientId).Result;
    }

    [HttpGet(Endpoints.GET_CAR_BY_ID)]
    public CarModel GetCarById(int carId)
    {
        return _service.GetCarById(carId).Result;
    }

    [HttpGet(Endpoints.GET_HOSPITAL_BY_ID)]
    public HospitalModel GetHospitalById(int hospitalId)
    {
        return _service.GetHospitalById(hospitalId).Result;
    }

    [HttpPost(Endpoints.ADD_RESPOND)]
    public IActionResult AddRespond([FromBody] RespondModel? model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        _service.AddRespond(model);

        return Ok();
    }

    [HttpPost(Endpoints.ADD_PATIENT)]
    public IActionResult AddPatient([FromBody] PatientModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        _service.AddPatient(model);

        return Ok();
    }

    [HttpPost(Endpoints.ADD_DOCTOR)]
    public IActionResult AddDoctor([FromBody] DoctorModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        _service.AddDoctor(model);

        return Ok();
    }

    [HttpPost(Endpoints.ADD_CAR)]
    public IActionResult AddCar([FromBody] CarModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        _service.AddCar(model);

        return Ok();
    }

    [HttpPost(Endpoints.ADD_HOSPITAL)]
    public IActionResult AddHospital([FromBody] HospitalModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        _service.AddHospital(model);

        return Ok();
    }

    [HttpPost(Endpoints.EDIT_RESPOND)]
    public IActionResult EditRespond(RespondModel model)
    {
        _service.EditRespond(model);

        return Ok();
    }
}