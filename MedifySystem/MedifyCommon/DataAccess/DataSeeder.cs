using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _userService!.InsertUser(new User("admin@test.com", UserRole.SystemAdmin, "Default", "Admin"));
        }
    }
}
