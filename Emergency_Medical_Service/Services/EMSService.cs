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
}