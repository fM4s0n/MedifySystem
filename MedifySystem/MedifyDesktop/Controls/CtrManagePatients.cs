using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrManagePatients : UserControl
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

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
    }
}
