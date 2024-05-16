using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// 
/// </summary>
public class User : Person
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }

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