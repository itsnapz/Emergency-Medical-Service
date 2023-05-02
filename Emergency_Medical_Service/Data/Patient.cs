namespace Emergency_Medical_Service.Data;

public enum Sex
{
    Male,
    Female
};

public class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Sex Sex { get; set; }
    public DateOnly Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
}