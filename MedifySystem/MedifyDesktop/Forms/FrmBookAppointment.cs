using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Form used to book an appointment with a doctor or nurse.
/// on behalf of the patient.
/// </summary>
public partial class FrmBookAppointment : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    private readonly IAppointmentService? _appointmentService = Program.ServiceProvider!.GetService(typeof(IAppointmentService)) as IAppointmentService;

    private readonly Patient? _patient;
    private User? _selectedOfficial;


    private List<Appointment>? _filledAppointments = [];
    private List<AppointmentTimeslot> _availableSlots = [];

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
        InitHospitalOfficialComboBox();
        InitDatePicker();

        SetFieldsVisible(false, false);
    }

    private void InitHospitalOfficialComboBox()
    {
        List<User>? availableOfficials = _userService!.GetAllUsers()?.Where(u => u.IsDoctorOrNurse()).OrderBy(u => u.LastName).ToList();

        if (availableOfficials == null || availableOfficials.Count == 0)
            return;

        foreach (User user in availableOfficials)
        {
            cmbSelectHospitalOfficial.Items.Add(user);
            cmbSelectHospitalOfficial.DisplayMember = "FullName";
            cmbSelectHospitalOfficial.ValueMember = "Id";
        }

        cmbSelectHospitalOfficial.SelectedIndex = -1;
    }

    private void InitDatePicker()
    {
        dtpSelectDate.MinDate = DateTime.Now.TimeOfDay > new TimeSpan(17, 0, 0) 
            ? DateTime.Now.Date.AddDays(1) 
            : DateTime.Now.Date;

        dtpSelectDate.MaxDate = DateTime.Now.AddYears(1);
    }

    private void GetAllAppointmentsForHospitalOfficial()
    {
        List<Appointment>? allAppts = _userService!.GetAllUpcomingAppointmentsForUser(_selectedOfficial!, false);

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

        DateTime selectedDate = dtpSelectDate.Value.Date;

        if (cmbSelectTime.SelectedItem is AppointmentTimeslot slot)
        {
            Appointment newAppointment = new(
                _patient!.Id,
                selectedDate.Add(slot.Start.TimeOfDay),
                slot.Duration,
                _selectedOfficial!.Id,
                string.Empty);

            _appointmentService!.InsertAppointment(newAppointment);

            MessageBox.Show(
                $"Appointment confirmed for {newAppointment.StartDate.ToShortDateString()} at {newAppointment.StartDate.ToShortTimeString()} \nlasting {slot.Duration.TotalMinutes} mins \nwith {_selectedOfficial.FullName}",
                "Appointment Booked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        else
        {
            MessageBox.Show("Please select a timeslot.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        if (cmbSelectTime.SelectedItem is AppointmentTimeslot slot)
        {
            if (slot.Start.TimeOfDay < new TimeSpan(9, 0, 0) || slot.Start.TimeOfDay.Add(slot.Duration) > new TimeSpan(17, 0, 0))
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
            _selectedOfficial = user;
            GetAllAppointmentsForHospitalOfficial();
        }
    }

    private void SetFieldsVisible(bool dateControl, bool timeControl)
    {
        dtpSelectDate.Visible = dateControl;
        lblSelectDate.Visible = dateControl;

        cmbSelectTime.Visible = timeControl;
        lblSelectTime.Visible = timeControl;

        //show times linked to date because we need to calculate available timeslots once a date is selected
        btnShowTimes.Visible = dateControl;
    }

    private void btnShowTimes_Click(object sender, EventArgs e)
    {
        SetAvailableTimeslots();

        if (_availableSlots.Count == 0)
        {
            MessageBox.Show("No available timeslots for the selected date.", "No Times", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        RefreshCmbSelectTime();
        SetFieldsVisible(true, true);
    }

    /// <summary>
    /// Sets the available timeslots for the selected date.
    /// </summary>
    /// <returns>true if any available for selected date, false if not</returns>
    private void SetAvailableTimeslots()
    {
        DateTime selectedDate = dtpSelectDate.Value.Date;

        int startHour;
        if (selectedDate == DateTime.Now.Date)
        {
            // use math.max and min to ensure we don't go below 9 or above 17
            startHour = Math.Max(DateTime.Now.AddHours(1).Hour, 9);
            startHour = Math.Min(startHour, 17); 
        }
        else
        {
            startHour = 9;
        }

        // Calculate the number of slots available from startHour to 17
        int count = (17 - startHour) + 1;

        if (count < 0)
            count = 1;

        List<Appointment>? currentAppointmentsForSelectedDate = _filledAppointments!
            .Where(a => a.StartDate.Date == selectedDate).ToList();

        List<TimeSpan> allSlots = Enumerable.Range(startHour, count)
            .Select(hour => TimeSpan.FromHours(hour)).ToList();

        List<TimeSpan> unavailableSlots = currentAppointmentsForSelectedDate
            .SelectMany(appt => allSlots
                .Where(slot => slot < appt.EndDate.TimeOfDay && slot.Add(TimeSpan.FromHours(1)) > appt.StartDate.TimeOfDay))
            .ToList();

        List<TimeSpan> availableSlots = allSlots.Except(unavailableSlots).ToList();

        _availableSlots.Clear();

        foreach (TimeSpan slot in availableSlots)
            _availableSlots.Add(new AppointmentTimeslot(selectedDate.Add(slot), TimeSpan.FromMinutes(60)));

        RefreshCmbSelectTime();
    }

    private void RefreshCmbSelectTime()
    {
        cmbSelectTime.Items.Clear();

        foreach (AppointmentTimeslot slot in _availableSlots)
            cmbSelectTime.Items.Add(slot);

        cmbSelectTime.SelectedIndex = 0;
    }

    private void RefreshAvailableTimeSlots()
    {
        _availableSlots.Clear();
        SetAvailableTimeslots();
    }

    private void dtpSelectDate_ValueChanged(object sender, EventArgs e)
    {
        RefreshAvailableTimeSlots();
    }
}
