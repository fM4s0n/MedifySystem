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

    private readonly List<string> _usedNhsNumbers = [];
    
    /// <summary>
    /// seeds the database with initial data
    /// </summary>
    public void SeedData()
    {
        SeedDefaultAdmin();
        SeedDefaultDoctor();
        SeedDefaultNurse();
        SeedDefaultPatinets();
        SeedRandomUsers();
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
            if (allPatients.Any(p => p.NHSNumber == "123456789") == false)
                SeedUnadmittedPatient();

            if (allPatients.Any(p => p.NHSNumber == "987654321") == false)
                SeedAdmittedPatient1();

            if (allPatients.Count == 2)
                SeedRandomPatients();
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

    private void SeedAdmittedPatient1()
    {
        Patient patient = new("Jane",
            "Doe",
            "987654321",
            Gender.Female,
            "Dr Jones",
            new DateTime(1980, 1, 1));

        _patientService!.InsertPatient(patient);

        User doctor = _userService!.GetUserByEmail("doctor@test.com")!;

        PatientAdmittance admittance = new(patient.Id, DateTime.Now, "Surgery", doctor.Id);
        _patientAdmittanceService!.InsertPatientAdmittance(admittance);
    }

    private void SeedRandomPatients()
    {
        Random random = new();

        for (int i = 0; i < 10; i++)
        {
            string firstName = $"Patient{i}";
            string lastName = $"Surname{i}";
            string nhsNumber = GenerateRandomNhsNumber();
            Gender gender = GenerateRandomGender();
            string gpName = $"Dr GP{i}";
            DateTime dateOfBirth = GenerateRandomDateOfBirth();
            bool admitted = random.Next(0, 1) == 1;

            Patient patient = new(firstName, lastName, nhsNumber, gender, gpName, dateOfBirth);
            _patientService!.InsertPatient(patient);

            if (admitted)
            {
                User doctor = _userService!.GetUserByEmail("doctor@test.com")!;

                PatientAdmittance admittance = new(patient.Id, DateTime.Now, "Surgery", doctor.Id);
                _patientAdmittanceService!.InsertPatientAdmittance(admittance);
            }
        }
    }

    private void SeedRandomUsers()
    {
        if (_userService!.GetAllUsers()?.Count > 10)
            return;

        Random random = new();

        for (int i = 0; i < 10; i++)
        {
            UserRole role = GenerateRandomUserRole();
            string email = $"{role}{i}@test.com";
            string firstName = $"{role}{i}";
            string lastName = $"Surname{i}";
            Gender gender = GenerateRandomGender();

            User user = new(email, role, firstName, lastName, gender);

            user.PasswordHash = PasswordHelper.HashPassword(user, "Password");
            _userService!.InsertUser(user);
        }
    }

    private UserRole GenerateRandomUserRole()
    {
        Random random = new();
        int randomNum = random.Next(0, 3);

        switch (randomNum)
        {
            case 0:
                return UserRole.SystemAdmin;
            case 1:
                return UserRole.Doctor;
            case 2:
                return UserRole.Nurse;
            default:
                return UserRole.Receptionist;
        }
    }


    private string GenerateRandomNhsNumber()
    {
        Random random = new();
        string nhsNumber = random.Next(100000000, 999999999).ToString();

        int maxAttempts = 1000000;
        int attempts = 0; 

        while (_usedNhsNumbers.Contains(nhsNumber) && attempts < maxAttempts)
        {
            nhsNumber = random.Next(100000000, 999999999).ToString();
            attempts++;
        }

        if (attempts >= maxAttempts)        
            throw new Exception("Unable to generate a unique NHS number.");        

        _usedNhsNumbers.Add(nhsNumber);

        return nhsNumber;
    }

    private static Gender GenerateRandomGender()
    {
        Random random = new();
        int genderRand = random.Next(0, 4);

        Gender genderValue = Gender.None;

        switch (genderRand)
        {
            case 0:
                genderValue = Gender.None;
                break;
            case 1:
                genderValue = Gender.Male;
                break;
            case 2:
                genderValue = Gender.Female;
                break;
            case 3:
                genderValue = Gender.NonBinary;
                break;
        }

        return genderValue;
    }

    private static DateTime GenerateRandomDateOfBirth()
    {
        Random random = new();
        DateTime startDate = new(1900, 1, 1);
        DateTime endDate = DateTime.Now;

        int dateRange = (endDate - startDate).Days;

        return startDate.AddDays(random.Next(dateRange));
    }
}
