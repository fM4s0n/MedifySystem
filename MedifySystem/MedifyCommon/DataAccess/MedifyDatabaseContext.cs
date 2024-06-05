using MedifySystem.MedifyCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace MedifySystem.MedifyCommon.DataAccess;

/// <summary>
/// Database context for Medify system
/// </summary>
/// <param name="options">DbContextOptions</param>
public class MedifyDatabaseContext(DbContextOptions<MedifyDatabaseContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientAdmittance> PatientAdmittances { get; set; }
    public DbSet<PatientRecord> PatientRecords { get; set; }
    public DbSet<PatientRecordDataEntry> PatientRecordDataEntries { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Patient>().ToTable("Patients");
        modelBuilder.Entity<PatientAdmittance>().ToTable("PatientAdmittances");
        modelBuilder.Entity<PatientRecord>().ToTable("PatientRecords");
        modelBuilder.Entity<PatientRecordDataEntry>().ToTable("PatientRecordDataEntries");
        modelBuilder.Entity<Appointment>().ToTable("Appointments");

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Admittances)
            .WithOne()
            .HasForeignKey(pa => pa.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PatientRecord>()
            .HasMany(pr => pr.DataEntries)
            .WithOne()
            .HasForeignKey(prde => prde.PatientRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
