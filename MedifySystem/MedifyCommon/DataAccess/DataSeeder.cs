using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Helpers;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyCommon.DataAccess;

/// <summary>
/// This class is used to seed the database with initial data.
/// </summary>
public class DataSeeder
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;
    
    /// <summary>
    /// 
    /// </summary>
    public void SeedData()
    {
        SeedDefaultAdmin();
        SeedDefaultDoctor();
        SeedDefaultNurse();
        SeedDefaultPatinets();
    }

    private void SeedDefaultAdmin()
    {
        List<User>? users = _userService!.GetAllUsers();

        if (users == null || users.Any(u => u.Email == "admin@test.com") == false)
        {
            User defaultAdmin = new("admin@test.com", UserRole.SystemAdmin, "Default", "Admin", Gender.Female);

            defaultAdmin.PasswordHash = PasswordHelper.HashPassword(defaultAdmin, "Password");

            _userService!.InsertUser(defaultAdmin);
        }
    }

    private void SeedDefaultDoctor()
    {
        List<User>? users = _userService!.GetAllUsers();

        if (users == null || users.Any(u => u.Email == "doctor@test.com") == false)
        {
            User defaultDoctor = new("doctor@test.com", UserRole.Doctor, "Default", "Doctor", Gender.NonBinary);

            defaultDoctor.PasswordHash = PasswordHelper.HashPassword(defaultDoctor, "Password");

            _userService!.InsertUser(defaultDoctor);
        }
    }

    private void SeedDefaultNurse()
    {
        List<User>? users = _userService!.GetAllUsers();

        if (users == null || users.Any(u => u.Email == "nurse@test.com") == false)
        {
            User defaultNurse = new("nurse@test.com", UserRole.Nurse, "Default", "Nurse", Gender.Male);

            defaultNurse.PasswordHash = PasswordHelper.HashPassword(defaultNurse, "Password");

            _userService!.InsertUser(defaultNurse);
        }
    }

    private void SeedDefaultPatinets()
    {
        List<Patient>? allPatients = _patientService!.GetAllPatients();

        if (allPatients != null)
        {
            if (allPatients.Any(p => p.NHSNumber == "123456789"))
                SeedUnadmittedPatient();

            if (allPatients.Any(p => p.NHSNumber == "987654321"))
                SeedAdmittedPatient();
        }        
    }

    private void SeedUnadmittedPatient()
    {
        Patient patient = new("Joe",
            "Bloggs",
            "123456789",
            Gender.Male,
            "Dr Smith",
            new DateTime(1990, 1, 1));

        _patientService!.InsertPatient(patient);
    }

    private void SeedAdmittedPatient()
    {
        Patient patient = new("Jane",
            "Doe",
            "987654321",
            Gender.Female,
            "Dr Jones",
            new DateTime(1980, 1, 1));

        _patientService!.InsertPatient(patient);

        Patient createdPateint = _patientService.GetPatientByNHSNumber("987654321")!;

        User doctor = _userService!.GetUserByEmail("doctor@test.com")!;

        PatientAdmittance admittance = new(createdPateint.Id, DateTime.Now, "Surgery", doctor.Id);
        _patientAdmittanceService!.InsertPatientAdmittance(admittance);
    }
}
