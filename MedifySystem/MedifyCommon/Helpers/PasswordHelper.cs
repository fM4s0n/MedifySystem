using MedifySystem.MedifyCommon.Models;
using Microsoft.AspNetCore.Identity;

namespace MedifySystem.MedifyCommon.Helpers;

/// <summary>
/// Password helper class to hash and verify passwords
/// </summary>
public static class PasswordHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string HashPassword(User user, string password)
    {
        PasswordHasher<User> ph = new();

        return ph.HashPassword(user, password);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="providedPassword"></param>
    /// <returns></returns>
    public static PasswordVerificationResult VerifyPassword(User user, string providedPassword)
    {
        PasswordHasher<User> ph = new();
        string hashedPassword = user.PasswordHash;

        PasswordVerificationResult result = ph.VerifyHashedPassword(user, hashedPassword, providedPassword);

        return result;
    }
}
