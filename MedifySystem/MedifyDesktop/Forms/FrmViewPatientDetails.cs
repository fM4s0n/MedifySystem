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

    // patient updated event so other forms can listen and update their views accordingly
    public delegate void PatientUpdatedHandler(object sender, EventArgs e);
    public event PatientUpdatedHandler? PatientUpdatedEvent;

    private Patient? _oldPatient;
    private readonly Patient? _newPatient;

    public FrmViewPatientDetails(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        // initially have new patient as the same as the old patient
        _newPatient = _oldPatient = patient;

        Init();
    }

    private void Init()
    {
        if (_oldPatient == null)
            return;

        InitGenderComboBox();
        SetPatientDetails();
    }

    private void SetPatientDetails()
    {
        lblCurrentFirstName.Text = _oldPatient!.FirstName;
        lblCurrentLastName.Text = _oldPatient.LastName;
        lblCurrentNHSNumber.Text = _oldPatient.NHSNumber;
        lblCurrentGPName.Text = _oldPatient.GPName;
        lblCurrentGender.Text = _oldPatient.Gender.ToString();
    }

    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))
        {
            if (gender == Gender.None)
                continue;

            cmbNewGender.Items.Add(gender);
        }

        cmbNewGender.SelectedIndex = -1;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNewFirstName.Text) == false)
            _newPatient!.FirstName = txtNewFirstName.Text;

        if (string.IsNullOrWhiteSpace(txtNewLastName.Text) == false)
            _newPatient!.LastName = txtNewLastName.Text;

        if (string.IsNullOrWhiteSpace(txtNewNHSNumber.Text) == false)
            _newPatient!.NHSNumber = txtNewNHSNumber.Text;

        if (string.IsNullOrWhiteSpace(txtNewGPName.Text) == false)
            _newPatient!.GPName = txtNewGPName.Text;

        if (cmbNewGender.SelectedItem is Gender newGender)
            _newPatient!.Gender = newGender;

        _patientService!.UpdatePatient(_newPatient!);     
        
        PatientUpdatedEvent?.Invoke(this, EventArgs.Empty);
        RefreshPatientDetails();
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void RefreshPatientDetails()
    {
        _oldPatient = _patientService!.GetPatientById(_oldPatient!.Id);
        SetPatientDetails();
        RefreshNewPatientDetails();
    }

    private void RefreshNewPatientDetails()
    {
        foreach (TextBox tb in new TextBox[] { txtNewFirstName, txtNewLastName, txtNewNHSNumber, txtNewGPName })
            tb.Clear();

        cmbNewGender.SelectedIndex = -1;
    }
}
