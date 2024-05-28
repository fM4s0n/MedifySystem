﻿using MedifySystem.MedifyCommon.Enums;
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

    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;

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
    public void LoginUser(User user)
    {
        if (user != null)
            _currentUser = user;

        OnLogin();
    }

    //<inheritdoc/>
    public void LogoutUser()
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
                    LoginUser(user);

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
}
