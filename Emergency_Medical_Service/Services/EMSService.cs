using Emergency_Medical_Service.Data;
using EMS.Lib;
using EMS.Lib.Models;

namespace Emergency_Medical_Service.Services;

public class EMSService
{
    private readonly HttpClient _client;

    public EMSService()
    {
        _client = new();
        _client.BaseAddress = new Uri(Endpoints.BASE);
    }

    public async Task<IEnumerable<RespondModel>> GetAllResponds()
    {
        return await _client.GetFromJsonAsync<IEnumerable<RespondModel>>($"{Endpoints.GET_RESPONDS}");
    }

    public async Task<IEnumerable<PatientModel>> GetAllPatients()
    {
        return await _client.GetFromJsonAsync<IEnumerable<PatientModel>>($"{Endpoints.GET_PATIENTS}");
    }

    public async Task<IEnumerable<DoctorModel>> GetAllDoctors()
    {
        return await _client.GetFromJsonAsync<IEnumerable<DoctorModel>>($"{Endpoints.GET_DOCTORS}");
    }

    public async Task<IEnumerable<CarModel>> GetAllCars()
    {
        return await _client.GetFromJsonAsync<IEnumerable<CarModel>>($"{Endpoints.GET_CARS}");
    }

    public async Task<IEnumerable<HospitalModel>> GetAllHospitals()
    {
        return await _client.GetFromJsonAsync<IEnumerable<HospitalModel>>($"{Endpoints.GET_HOSPITALS}");
    }

    public async Task<DoctorModel> GetDoctorById(int doctorId)
    {
        return await _client.GetFromJsonAsync<DoctorModel>($"{Endpoints.GET_DOCTOR_BY_ID}?{doctorId}");
    }

    public async Task<RespondModel> GetRespondById(int respondId)
    {
        return await _client.GetFromJsonAsync<RespondModel>($"{Endpoints.GET_RESPOND_BY_ID}?{respondId}");
    }

    public async Task<PatientModel> GetPatientById(int patientId)
    {
        return await _client.GetFromJsonAsync<PatientModel>($"{Endpoints.GET_PATIENT_BY_ID}?{patientId}");
    }

    public async Task<CarModel> GetCarById(int carId)
    {
        return await _client.GetFromJsonAsync<CarModel>($"{Endpoints.GET_CAR_BY_ID}?{carId}");
    }

    public async Task<HospitalModel> GetHospitalById(int hospitalId)
    {
        return await _client.GetFromJsonAsync<HospitalModel>($"{Endpoints.GET_HOSPITAL_BY_ID}?{hospitalId}");
    }

    public async Task AddRespond(RespondModel model)
    {
        await _client.PostAsJsonAsync<RespondModel>("/api/add/respond", model);
    }
}