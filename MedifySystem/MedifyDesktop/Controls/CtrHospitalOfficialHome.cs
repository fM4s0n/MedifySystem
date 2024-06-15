using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// UserControl for the Hospital Official Home
/// </summary>
public partial class CtrHospitalOfficialHome : UserControl
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly User? _user;

    public CtrHospitalOfficialHome()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _user = _userService!.GetCurrentUser();

        if (_user is null)
            _userService!.LogOutUser();

        Init();
    }

    private void Init()
    {
        SetAppointmentHomeItem();
    }

    private void SetAppointmentHomeItem()
    {
        // appointments today
        int appointmentsToday = _userService!.GetAllUpcomingAppointmentsForUser(_user!, false)?.Where(a => a.StartDate.Date == DateTime.Now.Date).Count() ?? 0;
        CtrFlpHomeItem appointmentHomeItem = new("Appointments Today", appointmentsToday.ToString() , FlpHomeItemBackColour.Orange);
    }
}
