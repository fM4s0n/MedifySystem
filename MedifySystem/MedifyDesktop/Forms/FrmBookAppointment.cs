using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using Windows.System.UserProfile;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Form used to book an appointment with a doctor or nurse.
/// on behalf of the patient.
/// </summary>
public partial class FrmBookAppointment : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly Patient? _patient;
    private User? _user;
    private Dictionary<DateTime, Appointment> _appointments = [];

    List<Appointment>? _filledAppointments = [];
    List<TimeSpan> _availableSlots = [];

    public FrmBookAppointment(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        ArgumentNullException.ThrowIfNull(patient);

        _patient = patient;
        _user = _userService!.GetCurrentUser()!;

        Init();
    }

    private void Init()
    {
        InitComboBox();
        InitDatePicker();
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

    private void InitDatePicker()
    {
        dtpSelectDate.MinDate = DateTime.Now;
        dtpSelectDate.MaxDate = DateTime.Now.AddYears(1);
    }

    private void GetAllAppointmentsForHospitalOfficial()
    {
        List<Appointment>? allAppts = _userService!.GetAllUpcomingAppointmentsForUser(_user!, false);

        DateTime calendarStart = DateTime.Now.Date;
        DateTime calendarEnd = DateTime.Now.Date.AddYears(1);

        if (allAppts == null)
        {
            _filledAppointments = [];
            return;
        }

        allAppts = allAppts.Where(a => a.StartDate >= calendarStart && a.StartDate <= calendarEnd).ToList();

        _filledAppointments!.Clear();
        _filledAppointments = allAppts;

        SetFieldsVisible(true, false);
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        if (ValidateAllFields() == false)
        {
            MessageBox.Show("Please fill in all fields.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }


    }

    private bool ValidateAllFields()
    {
        return ValidateSelectedHospitalOfficial() 
               && ValidateSelectedDate() 
               && ValidateSelectedTime();
    }

    private bool ValidateSelectedHospitalOfficial()
    {
        if (cmbSelectHospitalOfficial.SelectedItem is User user)
        {
            if (user.IsDoctorOrNurse() == false)            
                return false;
            
            return true;
        }

        return false;
    }

    private bool ValidateSelectedDate()
    {
        if (dtpSelectDate.Value.Date < DateTime.Now.Date)
            return false;

        if (dtpSelectDate.Value.Date > DateTime.Now.Date.AddYears(1))
            return false;

        return true;
    }

    private bool ValidateSelectedTime()
    {
        if (cmbSelectTime.SelectedItem is TimeSpan slot)
        {
            if (slot < TimeSpan.FromHours(9) || slot > TimeSpan.FromHours(17))
                return false;

            if (_availableSlots.Contains(slot) == false)
                return false;

            return true;
        }

        return false;
    }

    private void cmbSelectHospitalOfficial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbSelectHospitalOfficial.SelectedItem is User user)
        {
            _user = user;
            GetAllAppointmentsForHospitalOfficial();
        }
    }

    private void SetFieldsVisible(bool dateControl, bool timeControl)
    {
        dtpSelectDate.Visible = dateControl;
        cmbSelectTime.Visible = timeControl;

        btnShowTimes.Visible = dateControl;
    }

    private void btnShowTimes_Click(object sender, EventArgs e)
    {
        if (CalculateAvailableTimeslots() == false)
        {
            MessageBox.Show("No available timeslots for the selected date.", "No Times", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        RefreshCmbSelectTime();
        SetFieldsVisible(true, true);
    }

    private bool CalculateAvailableTimeslots()
    {
        DateTime selectedDate = dtpSelectDate.Value.Date;

        List<Appointment>? allApptsForSelectedDate = _filledAppointments!.Where(a => a.StartDate.Date == selectedDate).ToList();

        List<TimeSpan> allSlots = [];
        List<TimeSpan> unavailableSlots = [];
        List<TimeSpan> availableSlots = [];

        // create list of all slots from 9am to 5pm
        allSlots.AddRange(Enumerable.Range(9, 17).Select(hour => TimeSpan.FromHours(hour)));

        // check if any appointments are scheduled for the selected date and add to unavailable slots
        unavailableSlots.AddRange(allApptsForSelectedDate
                                    .SelectMany(appt => allSlots
                                    .Where(slot => slot >= appt.StartDate.TimeOfDay && slot <= appt.EndDate.TimeOfDay)));

        // get available slots by removing unavailable slots from all slots
        availableSlots = allSlots.Except(unavailableSlots).ToList();

        return availableSlots.Count > 0;
    }

    private void RefreshCmbSelectTime()
    {
        cmbSelectTime.Items.Clear();

        foreach (TimeSpan slot in _availableSlots)
            cmbSelectTime.Items.Add(slot);

        cmbSelectTime.SelectedIndex = 0;
    }
}
