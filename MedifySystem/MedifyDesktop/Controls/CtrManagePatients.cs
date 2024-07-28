using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrManagePatients : UserControl
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;

    private readonly List<Patient> _allPatients = [];
    private readonly List<Patient> _lvPatientDataSource = [];

    private readonly ColumnHeader[] _lvPatientsColumns =
    [
        new ColumnHeader { Text = "Full Name"},
        new ColumnHeader { Text = "NHS Number"},
        new ColumnHeader { Text = "Gender"},
        new ColumnHeader { Text = "GP Name" },
        new ColumnHeader { Text = "Admitted" },
    ];

    public CtrManagePatients()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        Init();
    }

    private void Init()
    {
        RefreshAllPatientsList();
        InitDateTimePicker();
        InitListView();
        InitGenderComboBox();
    }

    private void InitDateTimePicker()
    {
        dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1, 0, 0, 0);
        dtpDateOfBirth.MaxDate = DateTime.Now;
        dtpDateOfBirth.Value = new DateTime(1980, 1, 1, 0, 0, 0);
    }

    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))
        {
            if (gender == Gender.None)
                continue;

            cmbGender.Items.Add(gender);
        }            

        cmbGender.SelectedIndex = -1;
    }

    private void InitListView()
    {
        lvPatients.Columns.Clear();
        lvPatients.Columns.AddRange(_lvPatientsColumns);

        int colWidth = lvPatients.Width / _lvPatientsColumns.Length;
        foreach (ColumnHeader column in lvPatients.Columns)
            column.Width = colWidth;

        lvPatients.Resize += lvPatients_Resize;
    }

    private void lvPatients_Resize(object? sender, EventArgs e)
    {
        int colWidth = lvPatients.Width / _lvPatientsColumns.Length;

        foreach (ColumnHeader column in lvPatients.Columns)
            column.Width = colWidth;
    }

    private void btnShowAll_Click(object sender, EventArgs e) => Search(true);

    private void btnSearch_Click(object sender, EventArgs e) => Search(false);

    private void Search(bool showAll)
    {
        string searchTerm = txtSearch.Text.Trim();

        if (showAll || string.IsNullOrWhiteSpace(searchTerm))
        {
            _lvPatientDataSource.Clear();
            _lvPatientDataSource.AddRange(_allPatients);
        }
        else
        {
            _lvPatientDataSource.Clear();
            _lvPatientDataSource.AddRange(
                _allPatients
                    .Where(p => p.FirstName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                             || p.LastName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.LastName));
        }

        RefreshListView();
    }

    private void RefreshListView()
    {
        lvPatients.Items.Clear();

        foreach (Patient patient in _lvPatientDataSource)
        {
            ListViewItem lvi = new(patient.FullName);

            lvi.SubItems.AddRange(new[]
            {
                patient.NHSNumber,
                patient.Gender.ToString(),
                patient.GPName,
                patient.IsCurrentlyAdmitted() ? "Yes" : "No"
            });

            lvi.Tag = patient;

            lvPatients.Items.Add(lvi);
        }
    }

    private void btnViewPatientDetails_Click(object sender, EventArgs e)
    {
        if (lvPatients.SelectedItems.Count == 0)
            MessageBox.Show("Please select a patient", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        Patient? selectedPatient = GetSelectedPatientFromListView();

        if (selectedPatient == null)
            return;

        FrmViewPatientDetails frmViewPatientDetails = new(selectedPatient);
        frmViewPatientDetails.PatientUpdatedEvent += FrmViewPatientDetails_PatientUpdatedEvent;
        frmViewPatientDetails.ShowDialog(this);
    }

    private void FrmViewPatientDetails_PatientUpdatedEvent(object sender, EventArgs e)
    {
        RefreshAllPatientsList();
        Search(true);
    }

    private void btnRegisterPatient_Click(object sender, EventArgs e)
    {
        if (ValidateNewPatientFields())
        {
            Gender gender = GetGenderFromComboBox();

            Patient newPatient = new(txtFirstName.Text, txtLastName.Text, txtNHSNumber.Text, gender, txtGPName.Text, dtpDateOfBirth.Value);
            _patientService!.InsertPatient(newPatient);

            MessageBox.Show(
                "Patient registered successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearNewPatientFields();
            RefreshAllPatientsList();
            Search(true);
        }
    }

    private bool ValidateNewPatientFields()
    {
        foreach (TextBox tb in new[] { txtFirstName, txtLastName, txtNHSNumber, txtGPName })
        {
            tb.Text = tb.Text.Trim();

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Please fill in all fields", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        if (ValidateGender() == false)
            return false;

        return true;
    }

    private bool ValidateGender()
    {
        Gender? gender = GetGenderFromComboBox();

        if (gender == null)
        {
            MessageBox.Show("Please select a gender", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void btnClearNewPatient_Click(object sender, EventArgs e) => ClearNewPatientFields();

    private void ClearNewPatientFields()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        dtpDateOfBirth.Value = dtpDateOfBirth.MinDate;
        txtNHSNumber.Text = string.Empty;
        txtGPName.Text = string.Empty;
        cmbGender.SelectedIndex = -1;
    }

    private void btnAdmitPatient_Click(object sender, EventArgs e)
    {
        Patient? patient = GetSelectedPatientFromListView();

        if (patient == null)
        {
            MessageBox.Show("Please select a patient", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (patient.IsCurrentlyAdmitted())
        {
            MessageBox.Show("Patient is already admitted", "Patient already admitted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FrmAdmitPatient frmAdmitPatient = new(patient);
        frmAdmitPatient.ShowDialog(this);
    }

    private Patient? GetSelectedPatientFromListView()
    {
        if (lvPatients.SelectedItems.Count == 0)
            return null;

        return lvPatients.SelectedItems[0]?.Tag as Patient ?? null;
    }

    private Gender GetGenderFromComboBox()
    {
        if (cmbGender.SelectedIndex == -1)
            return Gender.None;

        if (cmbGender.SelectedItem is Gender selectedOption)
            return selectedOption;

        return Gender.None;
    }

    private void btnUpdateRecord_Click(object sender, EventArgs e)
    {
        Patient? patient = GetSelectedPatientFromListView();

        if (patient == null)
        {
            MessageBox.Show("Please select a patient", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FrmManagePatientRecord frmUpdatePatientRecord = new(patient);
        frmUpdatePatientRecord.ShowDialog(this);
    }

    private void btnBookAppointment_Click(object sender, EventArgs e)
    {
        if (GetSelectedPatientFromListView() is Patient selectedPatient)
        {
            FrmBookAppointment frmBookAppointment = new(selectedPatient);
            frmBookAppointment.ShowDialog(this);
        }
        else
        {
            MessageBox.Show("Please select a patient", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e) => Search(false);    

    internal void RefreshAllPatientsList()
    {
        _allPatients.Clear();
        _allPatients.AddRange(_patientService!.GetAllPatients() ?? []);
    }
}
