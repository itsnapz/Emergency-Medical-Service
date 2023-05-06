using System.Runtime.InteropServices;
using Emergency_Medical_Service.Data;
using EMS.Lib.Models;
using Mapster;

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
}