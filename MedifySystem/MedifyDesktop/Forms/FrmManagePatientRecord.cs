using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmManagePatientRecord : Form
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;

    private readonly Patient? _patient; 
    
    public FrmManagePatientRecord(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;
    }
}
