namespace EMS.Lib.Models;

public class RespondModel
{
    public int RespondId { get; set; }
    public int DoctorId { get; set; }
    public int CarId { get; set; }
    public int PatientId { get; set; }
    public string Date { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
    
    public DoctorModel? DoctorModel { get; set; }
    public PatientModel? PatientModel { get; set; }
    public CarModel? CarModel { get; set; }
    
    public List<DoctorModel>? Doctors { get; set; }
    public List<CarModel>? Cars { get; set; }
    public List<PatientModel>? Patients { get; set; }
}