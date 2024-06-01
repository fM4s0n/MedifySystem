using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmUpdatePatientRecord : Form
{
    private readonly Patient? _patient; 
    
    public FrmUpdatePatientRecord(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;
    }
}
