using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// View patient details form
/// </summary>
public partial class FrmViewPatientDetails : Form
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;

    private Patient? _patient;

    public FrmViewPatientDetails(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;

        Init();
    }

    private void Init()
    {
        if (_patient == null)
            return;

        InitDateTimePicker();
        InitGenderComboBox();
        SetPatientDetails();
    }

    private void SetPatientDetails()
    {
        lblCurrentFirstName.Text = _patient!.FirstName;
        lblCurrentLastName.Text = _patient.LastName;
        lblCurrentDateOfBirth.Text = _patient.DateOfBirth.ToString("dd/MM/yyyy");
        lblCurrentNHSNumber.Text = _patient.NHSNumber;
        lblCurrentGPName.Text = _patient.GPName;
        lblCurrentGender.Text = _patient.Gender.ToString();
    }
    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))        
            cmbNewGender.Items.Add(gender);

        cmbNewGender.SelectedIndex = -1;
    }

    private void InitDateTimePicker()
    {
        dtpNewDateOfBirth.MinDate = new DateTime(1900, 1, 1, 0, 0, 0);
        dtpNewDateOfBirth.MaxDate = DateTime.Now;
        dtpNewDateOfBirth.Value = new DateTime(1950, 1, 1, 0, 0, 0);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAllFields() == false)
        {
            Patient? patient = GetPatientFromControls();

            if (patient == null)
            {
                MessageBox.Show("Failed to save patient details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _patientService!.UpdatePatient(patient);
            RefreshPatientDetails();
        }
    }

    private bool ValidateAllFields()
    {
        return ValidateTextBoxes() 
            && ValidateGender();
    }

    private bool ValidateTextBoxes()
    {
        foreach (TextBox tb in new[] { txtNewFirstName, txtNewLastName, txtNewNHSNumber, txtNewGPName })
        {
            tb.Text = tb.Text.Trim();

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        return true;
    }

    private bool ValidateGender()
    {
        if (cmbNewGender.SelectedItem is Gender)        
            return true;        
        else        
            MessageBox.Show("Please select a gender", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        return false;            
    }

    private Patient? GetPatientFromControls()
    {
        if (cmbNewGender.SelectedItem is Gender gender)
        {
            return new Patient(
                txtNewFirstName.Text,
                txtNewLastName.Text,
                txtNewNHSNumber.Text,
                gender,
                txtNewGPName.Text,
                dtpNewDateOfBirth.Value);
        }

        return null;
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void cmbNewGender_SelectedIndexChanged(object sender, EventArgs e)
    { 
        if (cmbNewGender.SelectedItem is Gender.NonBinary)        
            txtNewGender.Visible = true;        
        else        
            txtNewGender.Visible = false;        
    }

    private void RefreshPatientDetails()
    {
        _patient = _patientService!.GetPatientById(_patient!.Id);
        SetPatientDetails();
    }
}
