using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrManagePatients : UserControl
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;

    private readonly List<Patient> _allPatients = [];
    private List<Patient> _lvPatientDataSource = [];

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
        lvPatients.Columns.Add("Full Name");
        lvPatients.Columns.Add("GP Name");
        lvPatients.Columns.Add("Admitted");
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
            MessageBox.Show("Please select a patient to view details", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            Gender? gender = GetGenderFromComboBox()!;
            string genderString;

            if (gender == Gender.NonBinary)            
                genderString = txtGender.Text;            
            else            
                genderString = gender.ToString()!;            

            Patient newPatient = new(txtFirstName.Text, txtLastName.Text, txtNHSNumber.Text, genderString, txtGPName.Text, dtpDateOfBirth.Value);
            _patientService!.InsertPatient(newPatient);
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

        if (gender == Gender.NonBinary)
        {
            txtGender.Text = txtGender.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                MessageBox.Show("Please specify Patient's gender", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        return true;
    }

    private void btnClearNewPatient_Click(object sender, EventArgs e) => ClearNewPatientFields();

    private void ClearNewPatientFields()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
    }

    private void btnAdmitPatient_Click(object sender, EventArgs e)
    {
        Patient? patient = GetSelectedPatientFromListView();

        if (patient == null)
            return;

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

    private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbGender.SelectedIndex == -1)
            return;

        Gender? gender = GetGenderFromComboBox();

        if (gender == Gender.NonBinary)
        {
            txtGender.Visible = true;
            lblGenderMessage.Visible = true;
        }
        else
        {
            txtGender.Text = string.Empty;
            txtGender.Visible = false;
            lblGenderMessage.Visible = false;
        }
    }

    private Gender? GetGenderFromComboBox()
    {
        if (cmbGender.SelectedIndex == -1)
            return null;

        if (cmbGender.SelectedItem is Gender selectedOption)
            return selectedOption;

        return null;
    }

    private void btnUpdateRecord_Click(object sender, EventArgs e)
    {
        Patient? patient = GetSelectedPatientFromListView();

        if (patient == null) 
            return;

        FrmManagePatientRecord frmUpdatePatientRecord = new(patient);
        frmUpdatePatientRecord.ShowDialog(this);
    }

    private void lvPatients_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
