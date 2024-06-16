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
        SetAppointmentsHomeItem();
        SetPatientsHomeItem();
    }

    private void SetAppointmentsHomeItem()
    {
        // appointments today
        int appointmentsToday = _userService!.GetAllUpcomingAppointmentsForUser(_user!, false)?
                                .Where(a => a.StartDate.Date == DateTime.Now.Date)
                                .Count() ?? 0;

        string subData = string.Empty;

        if (appointmentsToday == 0)
            subData = "No appointments scheduled for today.";

        CtrFlpHomeItem appointmentHomeItem = new(
            "Appointments Today", 
            appointmentsToday.ToString(),
            FlpHomeItemBackColour.Orange,
            subData);

        flpHome.Controls.Add(appointmentHomeItem);
    }

    private void SetPatientsHomeItem()
    {
        // patients today
        int patientsToday = _userService!.GetAllAdmittedPatientsForUser(_user!.Id)?
                            .Count ?? 0;

        string subData = string.Empty;

        if (patientsToday == 0)        
            subData = "No admitted patients admitted under your care.";        

        CtrFlpHomeItem patientHomeItem = new(
            "Patients Today",
            patientsToday.ToString(),
            FlpHomeItemBackColour.Blue,
            subData);

        flpHome.Controls.Add(patientHomeItem);
    }
}
