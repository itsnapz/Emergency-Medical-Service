using EMS.Lib.Enums;

namespace EMS.Lib.Models;

public class PatientModel
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Sex Sex { get; set; }
    public DateOnly Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }

    public string FullName { get { return this.Name + " " + this.Surname;} }
}