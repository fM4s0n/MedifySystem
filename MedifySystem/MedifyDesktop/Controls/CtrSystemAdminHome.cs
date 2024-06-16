using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// UserControl for the System Admin Home
/// </summary>
public partial class CtrSystemAdminHome : UserControl
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly List<User>? _allUsers;

    public CtrSystemAdminHome()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _allUsers = _userService!.GetAllUsers();

        if (_allUsers is null)
        {
            MessageBox.Show("No users found. Please contact the system administrator.", "No Users Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _userService!.LogOutUser();
        }


        Init();
    }

    private void Init()
    {
        SetTotalUsersHomeItem();
        SetDoctorsHomeItem();
        SetNursesHomeItem();
        SetReceptionistsHomeItem();
    }

    private void SetTotalUsersHomeItem()
    {
        int totalUsers = _allUsers!.Count;

        CtrFlpHomeItem totalUsersHomeItem = new(
            "Total Users",
            totalUsers.ToString(),
            FlpHomeItemBackColour.Blue);

        flpHome.Controls.Add(totalUsersHomeItem);
    }

    private void SetDoctorsHomeItem()
    {
        int doctors = _allUsers!.Where(u => u.Role == UserRole.Doctor).Count();
        string subData = string.Empty;

        if (doctors == 0)
            subData = "No doctors in the system.";


        CtrFlpHomeItem doctorsHomeItem = new(
            "Total Doctors",
            doctors.ToString(),
            FlpHomeItemBackColour.Green,
            subData);

        flpHome.Controls.Add(doctorsHomeItem);
    }

    private void SetNursesHomeItem()
    {
        int nurses = _allUsers!.Where(u => u.Role == UserRole.Nurse).Count();
        string subData = string.Empty;

        if (nurses == 0)
            subData = "No nurses in the system.";

        CtrFlpHomeItem nursesHomeItem = new(
            "Total Nurses",
            nurses.ToString(),
            FlpHomeItemBackColour.Orange,
            subData);

        flpHome.Controls.Add(nursesHomeItem);
    }

    private void SetReceptionistsHomeItem()
    {
        int receptionists = _allUsers!.Where(u => u.Role == UserRole.Receptionist).Count();
        string subData = string.Empty;

        if (receptionists == 0)
            subData = "No receptionists in the system.";

        CtrFlpHomeItem receptionistsHomeItem = new(
            "Total Receptionists",
            receptionists.ToString(),
            FlpHomeItemBackColour.Purple,
            subData);

        flpHome.Controls.Add(receptionistsHomeItem);
    }
}
