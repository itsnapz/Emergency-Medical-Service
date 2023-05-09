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
}