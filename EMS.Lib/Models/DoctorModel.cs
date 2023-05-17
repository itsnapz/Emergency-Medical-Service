using EMS.Lib.Enums;

namespace EMS.Lib.Models;

public class DoctorModel
{
    public int DoctorId { get; set; }
    public int HospitalId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Rank Rank { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateOnly Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string CallSign { get; set; }

    public HospitalModel? HospitalModel { get; set; }
    
    public List<HospitalModel>? Hospitals { get; set; }
    
    public string? FullName { get { return this.Name + " " + this.Surname; } }
}