﻿using Emergency_Medical_Service.Data;
using EMS.Lib;
using EMS.Lib.Models;
using Mapster;

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
        await _client.PostAsJsonAsync(Endpoints.ADD_RESPOND, model);
    }

    public async Task AddPatient(PatientModel model)
    {
        await _client.PostAsJsonAsync(Endpoints.ADD_PATIENT, model);
    }

    public async Task AddDoctor(DoctorModel model)
    {
        await _client.PostAsJsonAsync(Endpoints.ADD_DOCTOR, model);
    }

    public async Task AddCar(CarModel model)
    {
        await _client.PostAsJsonAsync(Endpoints.ADD_CAR, model);
    }

    public async Task AddHospital(HospitalModel model)
    {
        await _client.PostAsJsonAsync(Endpoints.ADD_HOSPITAL, model);
    }

    public async Task DeleteRespond(RespondModel model)
    {
        await _client.DeleteAsync($"/api/delete/respond/{model.RespondId}");
    }

    public async Task DeletePatient(PatientModel model)
    {
        await _client.DeleteAsync($"/api/delete/patient/{model.PatientId}");
    }

    public async Task DeleteDoctor(DoctorModel model)
    {
        await _client.DeleteAsync($"/api/delete/doctor/{model.DoctorId}");
    }

    public async Task DeleteCar(CarModel model)
    {
        await _client.DeleteAsync($"/api/delete/car/{model.CarId}");
    }

    public async Task DeleteHospital(HospitalModel model)
    {
        await _client.DeleteAsync($"/api/delete/hospital/{model.HospitalId}");
    }

    public async Task EditRespond(RespondModel model)
    {
        await _client.PutAsJsonAsync($"/api/edit/respond/{model.RespondId}", model);
    }

    public async Task EditPatient(PatientModel model)
    {
        await _client.PutAsJsonAsync($"/api/edit/patient/{model.PatientId}", model);
    }

    public async Task EditDoctor(DoctorModel model)
    {
        await _client.PutAsJsonAsync($"/api/edit/doctor/{model.DoctorId}", model);
    }

    public async Task EditCar(CarModel model)
    {
        await _client.PutAsJsonAsync($"/api/edit/car/{model.CarId}", model);
    }

    public async Task EditHospital(HospitalModel model)
    {
        await _client.PutAsJsonAsync($"/api/edit/hospital/{model.HospitalId}", model);
    }
}