using Microsoft.EntityFrameworkCore;

namespace Emergency_Medical_Service.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Respond> Responds { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}