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

    private readonly Patient? _patient;

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
        lblCurrentGender.Text = _patient.Gender;
    }
    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))        
            cmbNewGender.Items.Add(gender);            
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
            _patientService!.UpdatePatient (GetPatientFromControls());
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

    private Patient GetPatientFromControls()
    {
        return new Patient(
            txtNewFirstName.Text, 
            txtNewLastName.Text, 
            txtNewNHSNumber.Text, 
            cmbNewGender.Text, 
            txtNewGPName.Text, 
            dtpNewDateOfBirth.Value);
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
