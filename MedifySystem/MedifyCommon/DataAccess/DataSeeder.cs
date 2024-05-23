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
    
    /// <summary>
    /// 
    /// </summary>
    public void SeedData()
    {
        SeedDefaultAdmin();
    }

    private void SeedDefaultAdmin()
    {
        List<User>? users = _userService!.GetAllUsers();

        if (users == null || users.Any(u => u.Email == "admin@test.com") == false)
        {
            User defaultAdmin = new("admin@test.com", UserRole.SystemAdmin, "Default", "Admin");

            defaultAdmin.PasswordHash = PasswordHelper.HashPassword(defaultAdmin, "Password");

            _userService!.InsertUser(defaultAdmin);
        }
    }
}
