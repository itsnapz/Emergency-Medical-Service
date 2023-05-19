using System.Runtime.InteropServices;
using Emergency_Medical_Service.Data;
using EMS.Lib.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Emergency_Medical_Service.Services;

public class APIService
{
    private readonly ApplicationDbContext _database;

    public APIService(ApplicationDbContext database)
    {
        _database = database;
    }

    public Task<IEnumerable<EMS.Lib.Models.RespondModel>> GetAllResponds()
    {
        var responds = _database.Responds.ProjectToType<EMS.Lib.Models.RespondModel>();

        return Task.FromResult<IEnumerable<EMS.Lib.Models.RespondModel>>(responds);
    }
    
    public Task<IEnumerable<EMS.Lib.Models.PatientModel>> GetAllPatients()
    {
        var patients = _database.Patients.ProjectToType<EMS.Lib.Models.PatientModel>();

        return Task.FromResult<IEnumerable<EMS.Lib.Models.PatientModel>>(patients);
    }

    public Task<IEnumerable<DoctorModel>> GetAllDoctors()
    {
        var doctors = _database.Doctors.ProjectToType<DoctorModel>();

        return Task.FromResult<IEnumerable<DoctorModel>>(doctors);
    }

    public Task<IEnumerable<CarModel>> GetAllCars()
    {
        var cars = _database.Cars.ProjectToType<CarModel>();

        return Task.FromResult<IEnumerable<CarModel>>(cars);
    }

    public Task<IEnumerable<HospitalModel>> GetAllHospitals()
    {
        var hospitals = _database.Hospitals.ProjectToType<HospitalModel>();

        return Task.FromResult<IEnumerable<HospitalModel>>(hospitals);
    }

    public Task<DoctorModel> GetDoctorById(int doctorId)
    {
        var doctor = _database.Doctors.ProjectToType<DoctorModel>().FirstOrDefault(x => x.DoctorId == doctorId);

        return Task.FromResult<DoctorModel>(doctor);
    }

    public Task<RespondModel> GetRespondById(int respondId)
    {
        var respond = _database.Responds.ProjectToType<RespondModel>().FirstOrDefault(x => x.RespondId == respondId);

        return Task.FromResult<RespondModel>(respond);
    }

    public Task<PatientModel> GetPatientById(int patientId)
    {
        var patient = _database.Patients.ProjectToType<PatientModel>().FirstOrDefault(x => x.PatientId == patientId);

        return Task.FromResult<PatientModel>(patient);
    }

    public Task<CarModel> GetCarById(int carId)
    {
        var car = _database.Cars.ProjectToType<CarModel>().FirstOrDefault(x => x.CarId == carId);

        return Task.FromResult<CarModel>(car);
    }

    public Task<HospitalModel> GetHospitalById(int hospitalId)
    {
        var hospital = _database.Hospitals.ProjectToType<HospitalModel>()
            .FirstOrDefault(x => x.HospitalId == hospitalId);

        return Task.FromResult<HospitalModel>(hospital);
    }

    public void AddRespond(RespondModel model)
    {
        var dto = model.Adapt<Respond>();
        _database.Responds.Add(dto);
        _database.SaveChanges();
    }

    public void AddPatient(PatientModel model)
    {
        var dto = model.Adapt<Patient>();
        _database.Patients.Add(dto);
        _database.SaveChanges();
    }

    public void AddDoctor(DoctorModel model)
    {
        var dto = model.Adapt<Doctor>();
        _database.Doctors.Add(dto);
        _database.SaveChanges();
    }

    public void AddCar(CarModel model)
    {
        var dto = model.Adapt<Car>();
        _database.Cars.Add(dto);
        _database.SaveChanges();
    }

    public void AddHospital(HospitalModel model)
    {
        var dto = model.Adapt<Hospital>();
        _database.Hospitals.Add(dto);
        _database.SaveChanges();
    }

    public void DeleteRespond(int id)
    {
        var respond = _database.Responds.Find(id);

        _database.Responds.Remove(respond);
        _database.SaveChanges();
    }

    public void DeletePatient(int id)
    {
        var patient = _database.Patients.Find(id);

        _database.Patients.Remove(patient);
        _database.SaveChanges();
    }

    public void DeleteDoctor(int id)
    {
        var doctor = _database.Doctors.Find(id);

        _database.Doctors.Remove(doctor);
        _database.SaveChanges();
    }

    public void DeleteCar(int id)
    {
        var car = _database.Cars.Find(id);

        _database.Cars.Remove(car);
        _database.SaveChanges();
    }

    public void DeleteHospital(int id)
    {
        var hospital = _database.Hospitals.Find(id);

        _database.Hospitals.Remove(hospital);
        _database.SaveChanges();
    }

    public void EditRespond(int id, RespondModel model)
    {
        var dto = model.Adapt<Respond>();
        var respond = _database.Responds.FirstOrDefault(x => x.RespondId == dto.RespondId);

        respond.Price = dto.Price;
        respond.Street = dto.Street;
        respond.DoctorId = dto.DoctorId;
        respond.CarId = dto.CarId;
        respond.PatientId = dto.PatientId;
        respond.Postal = dto.Postal;

        _database.SaveChanges();
    }

    public void EditPatient(int id, PatientModel model)
    {
        var dto = model.Adapt<Patient>();
        var patient = _database.Patients.FirstOrDefault(x => x.PatientId == dto.PatientId);

        patient.Postal = dto.Postal;
        patient.Street = dto.Street;
        patient.Name = dto.Street;
        patient.Surname = dto.Surname;
        patient.Birthday = dto.Birthday;
        patient.PhoneNumber = dto.PhoneNumber;
        patient.Sex = dto.Sex;

        _database.SaveChanges();
    }

    public void EditDoctor(int id, DoctorModel model)
    {
        var dto = model.Adapt<Doctor>();
        var doctor = _database.Doctors.FirstOrDefault(x => x.DoctorId == dto.DoctorId);

        doctor.HospitalId = dto.HospitalId;
        doctor.Name = dto.Name;
        doctor.Surname = dto.Surname;
        doctor.Birthday = dto.Birthday;
        doctor.Rank = dto.Rank;
        doctor.CallSign = dto.CallSign;
        doctor.PhoneNumber = dto.PhoneNumber;

        _database.SaveChanges();
    }

    public void EditCar(int id, CarModel model)
    {
        var dto = model.Adapt<Car>();
        var car = _database.Cars.FirstOrDefault(x => x.CarId == dto.CarId);

        car.Name = dto.Name;
        car.Plate = dto.Plate;

        _database.SaveChanges();
    }

    public void EditHospital(int id, HospitalModel model)
    {
        var dto = model.Adapt<Hospital>();
        var hospital = _database.Hospitals.FirstOrDefault(x => x.HospitalId == dto.HospitalId);

        hospital.Name = dto.Name;
        hospital.Postal = dto.Postal;
        hospital.Street = dto.Street;
    }
}