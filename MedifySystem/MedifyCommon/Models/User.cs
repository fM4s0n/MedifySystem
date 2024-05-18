using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// User class, this can be a hostpital official or a system admin
/// </summary>
public class User(string email, UserRole userRole, string firstName, string lastName) : Person(firstName, lastName)
{
    public string Email { get; set; } = email;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; } = userRole;

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
}