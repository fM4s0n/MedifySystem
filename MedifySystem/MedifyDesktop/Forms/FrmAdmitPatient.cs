using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Admit patient form
/// </summary>
public partial class FrmAdmitPatient : Form
{
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly Patient? _patient;
    private List<User>? _allHospitalOfficials = [];

    public FrmAdmitPatient(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        if (patient == null)
        {
            MessageBox.Show("Patient not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        _patient = patient;

        if (_patient!.IsCurrentlyAdmitted())
        {
            MessageBox.Show("Patient is already admitted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        Init();
    }

    private void Init()
    {
        lblPatientName.Text = _patient!.FullName;
        dtpAdmittance.MaxDate = DateTime.Now;

        _allHospitalOfficials = _userService!.GetAllUsers()?.Where(u => u.IsDoctorOrNurse()).ToList();

        InitComboBox();
    }

    private void InitComboBox()
    {
        foreach (User hospitalOfficial in _allHospitalOfficials!.OrderBy(ho => ho.LastName).ToList())
            cmbHospitalOfficial.Items.Add(hospitalOfficial.FullName);
    }

    private void btnAdmitPatient_Click(object sender, EventArgs e)
    {
        if (ValidateAllFields() == false)
        {
            MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _patientService?.AdmitPatient(_patient!, GetHospitalOfficialId(), txtReason.Text);

        MessageBox.Show("Patient admitted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }

    private bool ValidateAllFields()
    {
        return string.IsNullOrWhiteSpace(txtReason.Text) == false
            && string.IsNullOrWhiteSpace(GetHospitalOfficialId()) == false;
    }

    private string GetHospitalOfficialId()
    {
        if (cmbHospitalOfficial.SelectedItem is string name && string.IsNullOrWhiteSpace(name) == false)
        {
            User? hospitalOfficial = _allHospitalOfficials!.FirstOrDefault(ho => ho.FullName == name);
            return hospitalOfficial?.Id ?? string.Empty;
        }

        return string.Empty;
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
