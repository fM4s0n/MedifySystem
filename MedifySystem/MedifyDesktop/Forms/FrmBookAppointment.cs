using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmBookAppointment : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly Patient _patient;
    private readonly User _user;
    private Dictionary<DateTime, Appointment> _appointments = [];

    List<Appointment>? _filledAppointments;

    public FrmBookAppointment(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        ArgumentNullException.ThrowIfNull(patient);

        _patient = patient;

        Init();
    }

    private void Init()
    {
        InitCalendar();
        InitComboBox();
    }

    private void InitComboBox()
    {
        List<User>? allUsers = _userService!.GetAllUsers();

        if (allUsers == null)
            return;

        foreach (User user in allUsers.Where(u => u.IsDoctorOrNurse()).OrderBy(u => u.LastName).ToList())
        {
            cmbSelectHospitalOfficial.Items.Add(user);
            cmbSelectHospitalOfficial.DisplayMember = "FullName";
            cmbSelectHospitalOfficial.ValueMember = "Id";
        }

        if (_userService!.GetCurrentUser()!.IsDoctorOrNurse())
            cmbSelectHospitalOfficial.SelectedItem = _userService.GetCurrentUser();
        else
            cmbSelectHospitalOfficial.SelectedIndex = 0;
    }

    private void InitCalendar()
    {
        calAppointments.MaxSelectionCount = 1;
        calAppointments.MinDate = DateTime.Now;

        _filledAppointments = _userService!.GetAllUpcomingAppointmentsForUser(_user);

        if (_filledAppointments == null)
            return;

        // bold out all dates that are already booked
        foreach (Appointment appointment in _filledAppointments)
            calAppointments.AddBoldedDate(appointment.AppointmentStartDate);
    }

    private void GetAllAppointmentsForUser()
    {
        List<Appointment>? allAppts = _userService!.GetAllUpcomingAppointmentsForUser(_user, false);

        DateTime calendarStart = DateTime.Now.Date;
        DateTime calendarEnd = DateTime.Now.Date.AddYears(1);


    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void btnConfirm_Click(object sender, EventArgs e)
    {

    }
}
