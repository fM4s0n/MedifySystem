using MedifySystem.MedifyCommon.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// User class, this can be a hospital official or a system admin
/// </summary>
public class User : Person
{
    public User() { }

    public User(string email, UserRole userRole, string firstName, string lastName, Gender gender)
    { 
        Email = email.ToLower();
        Role = userRole;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool RequiresPasswordReset { get; set; } = true;
    public UserRole Role { get; set; } = UserRole.SystemAdmin;

    /// <summary>
    /// Is the user a hospital official
    /// </summary>
    /// <returns>
    /// True if doctor, nurse or Receptionist.
    /// False if not
    /// </returns>
    public bool IsHospitalOfficial()
    {
        return Role == UserRole.Doctor || Role == UserRole.Nurse || Role == UserRole.Receptionist;
    }

    public bool IsDoctorOrNurse()
    {
        return Role == UserRole.Doctor || Role == UserRole.Nurse;
    }
}