using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmViewPatientDetails : Form
{
    private readonly Patient? _patient;

    public FrmViewPatientDetails(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;
    }
}
