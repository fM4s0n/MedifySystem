using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Patient record management form.
/// </summary>
public partial class FrmManagePatientRecord : Form
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;

    private readonly Patient? _patient; 
    private PatientRecord? _patientRecord;

    public FrmManagePatientRecord(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;

        if (_patient == null)
        {
            MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        Init();
    }

    private void Init()
    {
        SetPatientRecord();
    }

    private void SetPatientRecord()
    {
        _patientRecord = _patientService!.GetPatientRecord(_patient!.Id);
    }
}
