using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrManagePatients : UserControl
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;

    private List<Patient> _allPatients = [];

    public CtrManagePatients()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _allPatients = _patientService!.GetAllPatients() ?? [];

        InitListView();
    }

    private void InitListView()
    {
        lvPatients.Columns.Add("Full Name");

    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {

    }

    private void btnSearch_Click(object sender, EventArgs e)
    {

    }

    private void btnViewPatientDetails_Click(object sender, EventArgs e)
    {
        if (lvPatients.SelectedItems.Count == 0)
            MessageBox.Show("Please select a patient to view details", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        Patient? selectedPatient = (Patient)lvPatients.SelectedItems[0].Tag;

        if (selectedPatient == null)
            return;


    }

    private void btnRegisterPatient_Click(object sender, EventArgs e)
    {
        if (ValidateNewPatientFields())
        {
            Patient newPatient = new(txtFirstName.Text, txtLastName.Text);

            _patientService!.InsertPatient(newPatient);
        }
    }

    private bool ValidateNewPatientFields()
    {
        txtFirstName.Text = txtFirstName.Text.Trim();
        txtLastName.Text = txtLastName.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            return false;

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
        Patient? patient = GetSelectedPateintFromListView();

        if (patient == null)
            return;

        if (patient.IsCurrentlyAdmitted())
        {
            MessageBox.Show("Patient is already admitted", "Patient already admitted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FrmAdmitPatient frmAdmitPatient = new(patient);
    }

    private Patient? GetSelectedPateintFromListView()
    {
        if (lvPatients.SelectedItems.Count == 0)
            return null;

        return lvPatients.SelectedItems[0]?.Tag as Patient ?? null;
    }
}
