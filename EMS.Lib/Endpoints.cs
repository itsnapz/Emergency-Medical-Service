namespace EMS.Lib;

public class Endpoints
{
    public const string BASE = "https://localhost:7265";
    
    public const string GET_RESPONDS = "/api/responds";
    public const string GET_PATIENTS = "/api/patients";
    public const string GET_DOCTORS = "/api/doctors";
    public const string GET_CARS = "/api/cars";
    public const string GET_HOSPITALS = "/api/hospitals";

    public const string GET_RESPOND_BY_ID = "/api/respond";
    public const string GET_PATIENT_BY_ID = "/api/patient";
    public const string GET_DOCTOR_BY_ID = "/api/doctor";
    public const string GET_CAR_BY_ID = "/api/car";
    public const string GET_HOSPITAL_BY_ID = "/api/hospital";

    public const string ADD_RESPOND = "/api/add/respond";
    public const string ADD_PATIENT = "/api/add/patient";
    public const string ADD_DOCTOR = "/api/add/doctor";
    public const string ADD_CAR = "/api/add/car";
    public const string ADD_HOSPITAL = "/api/add/hospital";

    public const string EDIT_RESPOND = "/api/edit/respond";
    public const string EDIT_PATIENT = "/api/edit/patient";
    public const string EDIT_DOCTOR = "/api/edit/doctor";
    public const string EDIT_CAR = "/api/edit/car";
    public const string EDIT_HOSPITAL = "/api/edit/hospital";

    public const string DELETE_RESPOND = "/api/delete/respond/";
    public const string DELETE_PATIENT = "/api/delete/patient";
    public const string DELETE_DOCTOR = "/api/delete/patient";
    public const string DELETE_CAR = "/api/delete/car";
    public const string DELETE_HOSPITAL = "/api/delete/hospital";
}