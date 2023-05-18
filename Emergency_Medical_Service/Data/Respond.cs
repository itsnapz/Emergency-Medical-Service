using System.Runtime.InteropServices.JavaScript;

namespace Emergency_Medical_Service.Data;

public class Respond
{
    public int RespondId { get; set; }
    public int DoctorId { get; set; }
    public int CarId { get; set; }
    public int PatientId { get; set; }
    public double Price { get; set; }
    public string Date { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    public virtual Car Car { get; set; }
    public virtual Patient Patient { get; set; }
}