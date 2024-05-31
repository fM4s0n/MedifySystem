using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Forms;
public partial class FrmPatientDetails : Form
{
    private readonly Patient? _patient;

    public FrmPatientDetails(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;
    }

    private void Init()
    {

    }
}
