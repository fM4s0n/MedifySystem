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

    public CtrManagePatients()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _allPatients = _patientService!.GetAllPatients() ?? [];

        Init();
    }

    private void Init()
    {
        InitDateTimePicker();
        InitListView();
        InitGenderComboBox();
    }

    private void InitDateTimePicker()
    {
        dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1, 0, 0, 0);
        dtpDateOfBirth.MaxDate = DateTime.Now;
        dtpDateOfBirth.Value = new DateTime(1950, 1, 1, 0, 0, 0);
    }

    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            cmbGender.Items.Add(gender);

        cmbGender.SelectedIndex = -1;
    }

    private void InitListView()
    {
        int width = lvPatients.Width / 3;

        lvPatients.Columns.Clear();
        lvPatients.Columns.Add("Full Name", width);
        lvPatients.Columns.Add("GP Name", width);
        lvPatients.Columns.Add("Admitted", width);
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
            _lvPatientDataSource.AddRange(_allPatients.Where
                    (p => p.FirstName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
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

            lvi.SubItems.Add(patient.GPName);
            lvi.SubItems.Add(patient.IsCurrentlyAdmitted() ? "Yes" : "No");
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
        frmViewPatientDetails.ShowDialog(this);
    }

    private void btnRegisterPatient_Click(object sender, EventArgs e)
    {
        if (ValidateNewPatientFields())
        {
            Gender gender = GetGenderFromComboBox();

            Patient newPatient = new(txtFirstName.Text, txtLastName.Text, txtNHSNumber.Text, gender, txtGPName.Text, dtpDateOfBirth.Value);
            _patientService!.InsertPatient(newPatient);

            ClearNewPatientFields();
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
        dtpDateOfBirth.Value = DateTime.Now;
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
}
