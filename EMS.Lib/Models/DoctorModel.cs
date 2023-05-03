namespace EMS.Lib.Models;

public class DoctorModel
{
    public int DoctorId { get; set; }
    public int HospitalId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string CallSign { get; set; }
}