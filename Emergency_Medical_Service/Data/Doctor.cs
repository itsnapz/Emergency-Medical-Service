namespace Emergency_Medical_Service.Data;

public class Doctor
{
    public int DoctorId { get; set; }
    public int HospitalId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string CallSign { get; set; }
    
    public virtual Hospital Hospital { get; set; }
}