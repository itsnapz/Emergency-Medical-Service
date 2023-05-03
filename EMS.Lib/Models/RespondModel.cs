namespace EMS.Lib.Models;

public class RespondModel
{
    public int RespondId { get; set; }
    public int DoctorId { get; set; }
    public int CarId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
}