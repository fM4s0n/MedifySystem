using MedifySystem.MedifyCommon.Helpers;
using MedifySystem.MedifyCommon.Models;
using Microsoft.AspNetCore.Identity;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class UserService(IDBService? dbService = null) : IUserService
{
    private readonly IDBService? _dbService = dbService ?? Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;

    // Login and Logout event handlers
    public delegate void LogoutEventHandler(object sender, EventArgs e);
    public delegate void LoginEventHandler(object sender, EventArgs e);
    public delegate void ResetPasswordHandler(object sender, EventArgs e);

    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;
    public event ResetPasswordHandler? ResetPasswordEvent;

    private User? _currentUser = null;

    //<inheritdoc/>
    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    //<inheritdoc/>
    public void DeleteUser(User user)
    {
        _dbService!.DeleteEntity(user);
    }

    //<inheritdoc/>
    public List<User>? GetAllUsers()
    {
        return _dbService!.GetEntitiesByType<User>()!;
    }

    //<inheritdoc/>
    public User? GetUserById(string id)
    {
        return _dbService?.GetEntity<User>(id);
    }

    //<inheritdoc/>
    public void InsertUser(User user) 
    {
        // check for duplicate email
        List<User>? users = GetAllUsers();

        if (users != null)
        {
            foreach (User u in users)
            {
                if (u.Email == user.Email)
                    return;
            }
        }

        _dbService?.InsertEntity(user);
    } 

    //<inheritdoc/>
    public void LogInUser(User user, bool requiresReset = false)
    {
        if (user != null)
            _currentUser = user;

        if (requiresReset == false)
            OnLogin();
    }

    //<inheritdoc/>
    public void LogOutUser()
    {
        _currentUser = null;
        OnLogout();
    }
 
    //<inheritdoc/>
    public void UpdateUser(User user)
    {
        _dbService?.UpdateEntity(user);
    }

    //<inheritdoc/>
    public bool AuthenticateUser(string email, string password)
    {
        List<User>? users = GetAllUsers();
        if (users == null)
            return false;

        foreach (User user in users)
        {
            if (user.Email == email)
            {
                bool result = PasswordHelper.VerifyPassword(user, password) != PasswordVerificationResult.Failed;
                
                if (result)
                {
                    if (user.RequiresPasswordReset)
                    {
                        ResetPasswordEvent?.Invoke(this, EventArgs.Empty);
                        LogInUser(user, true);

                        return true;
                    }

                    LogInUser(user);
                }

                return result;
            }
        }

        return false;
    }

    /// <summary>
    /// Login Event
    /// </summary>
    public void OnLogin() => LogInEvent?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Logout Event
    /// </summary>
    public void OnLogout() => LogOutEvent?.Invoke(this, EventArgs.Empty);

    //<inheritdoc/>
    public List<Patient>? GetAllActivePatientsForUser(string userId)
    {
        List<PatientAdmittance>? admittances = _patientAdmittanceService?.GetAllPatientAdmittances()?.Where(pa => pa.HospitalOfficialId == userId).ToList();

        if (admittances == null)
            return null;

        List<Patient>? patients = [];

        foreach (PatientAdmittance admittance in admittances)
        {
            Patient? patient = _patientService?.GetPatientById(admittance.PatientId);

            if (patient != null)
                patients.Add(patient);
        }

        return patients;
    }

    //<inheritdoc/>
    public List<Appointment>? GetAllUpcomingAppointmentsForUser(User user, bool includedCancelled)
    {
        if (user.IsDoctorOrNurse() == false || user == null)
            return null;

        List<Appointment>? appointments = _dbService!.GetEntitiesByType<Appointment>()?
            .Where(a => a.HospitalOfficialId == user.Id && a.StartDate > DateTime.Now)
            .ToList();

        if (includedCancelled == false && appointments != null)        
            appointments = appointments.Where(a => a.IsCancelled == false).ToList();

        return appointments;
    }

    //<inheritdoc/>
    public User? GetUserByEmail(string email)
    {
        List<User>? users = GetAllUsers();

        if (users == null)
            return null;
        
        return users.FirstOrDefault(u => u.Email == email) ?? null;
    }
}
